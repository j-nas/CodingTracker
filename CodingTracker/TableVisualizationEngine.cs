using CodingTracker.Models;
using ConsoleTableExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class TableVisualizationEngine
    {
        public string table;
        
        public TableVisualizationEngine (List<CodingSession> sessions)
            
        {
            var tableData = new List<List<object>>();

            foreach (CodingSession session in sessions)
            {
                tableData.Add(new List<object> { session.Id, session.Duration, session.StartTime, session.EndTime });
            }

            table = ConsoleTableBuilder.From(tableData).Export().ToString();
        }
    }
}
