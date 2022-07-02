using CsvHelper;
using System.Globalization;

// See https://aka.ms/new-console-template for more information

// Read and get csv data
var reader = new StreamReader(@"OldData.csv");
var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
var records = csv.GetRecords<OldDataModel>();

// Set list to store record
var data = new List<NewDataModel>();

// sort out logic
foreach(var item in records)
{
    if(!string.IsNullOrEmpty(item.Tag1)) 
    {
        data.Add(new NewDataModel { Item = item.Item, Tag = item.Tag1 });
    }

    if(!string.IsNullOrEmpty(item.Tag2)) 
    {
        data.Add(new NewDataModel { Item = item.Item, Tag = item.Tag2 });
    }

    if(!string.IsNullOrEmpty(item.Tag3)) 
    {
        data.Add(new NewDataModel { Item = item.Item, Tag = item.Tag3 });
    }
}

// Write data to csv
using (var writer = new StreamWriter(@"NewData.csv"))
using (var write2csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
{
    write2csv.WriteRecords(data);
}