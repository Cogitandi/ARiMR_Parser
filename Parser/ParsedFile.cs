using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser
{
    public class ParsedFile
    {
        public static String UPRAWA = "GRUPA_RODZAJ_UPRAWA";
        public IList<FileEntry> Entries { get; set; } = new List<FileEntry>();

        public String GetResult()
        {
            var output = new StringBuilder();
            var cultivatedParcels = Entries.GetCultivatedEntries();
            var parsedFields = cultivatedParcels.GetParsedFields().OrderBy(x=>x.Uprawa);
            foreach(var parsedField in parsedFields)
            {
                output.Append(parsedField.ToString());
            }
            return output.ToString();
        }
    }
}
