using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser
{
    public static class Extensions
    {
        public static IEnumerable<FileEntry> GetCultivatedEntries(this IEnumerable<FileEntry> entries)
        {
            return entries.Where(entry => entry.GrupaUpraw.Equals(ParsedFile.UPRAWA));
        }
        public static IEnumerable<ParsedField> GetParsedFields(this IEnumerable<FileEntry> cultivatedEntries)
        {
            var parsedFields = cultivatedEntries.GetFields().ToList();

            foreach(var cultivatedEntry in cultivatedEntries)
            {
                var field = parsedFields.FirstOrDefault(parsedField => parsedField.NumerPola.Equals(cultivatedEntry.OznaczenieDzialkiRolnej));
                field.NumeryDzialek.Add(ParsedField.FetchParcelNumber(cultivatedEntry.NrDzialki));
                field.CalkowitaPowierzchnia += cultivatedEntry.PowierzchniaDzialkiRolnejWGranicachDzialkiEwid;
            }
            return parsedFields;
        }
        public static IEnumerable<ParsedField> GetFields(this IEnumerable<FileEntry> cultivatedEntry)
        {
            var createdFields = new List<String>();
            var parsedFields = new List<ParsedField>();
            foreach(var entry in cultivatedEntry)
            {
                if (createdFields.Contains(entry.OznaczenieDzialkiRolnej))
                    continue;
                var parsedField = new ParsedField()
                {
                    NumerPola = entry.OznaczenieDzialkiRolnej,
                    Uprawa = entry.RoslinaUprawna,
                };
                parsedFields.Add(parsedField);
                createdFields.Add(parsedField.NumerPola);
            }
            return parsedFields;
        }
    }
}
