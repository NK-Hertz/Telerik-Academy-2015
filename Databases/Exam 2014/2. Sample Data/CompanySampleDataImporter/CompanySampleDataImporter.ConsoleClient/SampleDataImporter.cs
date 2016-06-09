﻿namespace CompanySampleDataImporter.ConsoleClient
{
    using Data;
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public class SampleDataImporter
    {
        private TextWriter textWriter;

        private SampleDataImporter(TextWriter textWriter)
        {
            this.textWriter = textWriter;
        }

        public static SampleDataImporter Create(TextWriter textWriter)
        {
            return new SampleDataImporter(textWriter);
        }

        public void Import()
        {
            Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(IImporter).IsAssignableFrom(t)
                && !t.IsInterface)
                .Select(t => (IImporter)Activator.CreateInstance(t))
                .OrderBy(t => t.Order)
                .ToList()
                .ForEach(i =>
                {
                    textWriter.Write(i.Message);

                    var db = new CompanyEntities();
                    i.Get(db, this.textWriter);

                    textWriter.WriteLine();
                });

        }
    }
}
