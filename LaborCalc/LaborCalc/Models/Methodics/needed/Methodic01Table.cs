namespace LaborCalc.Models;

public class Methodic01Table : IReport
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string[] RowsNames { get; set; }
    public string[] RowsNamesDown { get; set; }
    public string[] ColumnsNames { get; set; }
    public string[] ColumnsNamesDown { get; set; }
    public double[,] Values { get; set; }

    public Methodic01Table(int id, string name,
        string[] rowsNames,
        string[] columnsNames,
        double[,] values)
    {
        Id = id;
        Name = name;

        RowsNames = rowsNames;

        ColumnsNames = columnsNames;

        Values = values;
    }

    public Methodic01Table(int id, string name,
        string[] rowsNames, string[] rowsNamesDown,
        string[] columnsNames, string[] columnsNamesDown,
        double[,] values)
    {
        Id = id;
        Name = name;

        RowsNames = rowsNames;
        RowsNamesDown = rowsNamesDown;

        ColumnsNames = columnsNames;
        ColumnsNamesDown = columnsNamesDown;

        Values = values;
    }

    public double this[string rowName, string colName]
    {
        get 
        {
            int r = RowsNames.Contains(rowName) ?
                Array.IndexOf(RowsNames, rowName) 
                : Array.IndexOf(RowsNamesDown, rowName);

            int c = RowsNames.Contains(colName) ?
                Array.IndexOf(ColumnsNames, colName)
                : Array.IndexOf(ColumnsNamesDown, colName);

            return Values[r, c];
        }
    }

    public double this[string rowName, string rowNameDown, string colName]
    {
        get
        {
            int r = 0;
            //var r1 = RowsNames.Where(x => x == rowName);
            //var r2 = RowsNames.Where(x => x == rowNameDown);
            //var r = r1.Intersect(r2).First();

            int c = RowsNames.Contains(colName) ?
                Array.IndexOf(ColumnsNames, colName)
                : Array.IndexOf(ColumnsNamesDown, colName);

            return Values[r, c];
        }
    }

    public static string GetColumnName(double num)
    {
        if (num < 1)
            throw new Exception($"There is no such column! {num}");
        else if (num == 1)
            return "1";
        else if (num == 2)
            return "2";
        else if (num <= 4)
            return "3-4";
        else if (num <= 6)
            return "5-6";
        else if (num <= 9)
            return "7-9";
        else if (num <= 14)
            return "10-14";
        else if (num <= 21)
            return "15-21";
        else if (num <= 30)
            return "22-30";
        else if (num <= 42)
            return "31-42";
        else
           throw new Exception($"Another method needed, {num} >= 42");
    }


    public override string ToString()
    {
        string str = $"{Id}. {Name}\n";

        str += "\t\t\t";
        for (int c = 0; c < Values.GetLength(1); c++)
        {
            str += ColumnsNames[c] + "\t\t\t";
        }
        str += "\n";


        for (int r = 0; r < Values.GetLength(0); r++)
        {

            //if (RowsNamesDown != null && RowsNames.Length == RowsNamesDown.Length)
            //    str += RowsNamesDown[r] + "\t\t" + RowsNames[r] + "\t\t\t";
            //else
            str += RowsNames[r] + "\t\t\t";

            for (int c = 0; c < Values.GetLength(1); c++)
            {
                str += Values[r, c] + "\t\t\t";
            }
        }

        return str;
    }

    public string ToHtml()
    {
        throw new NotImplementedException();
    }
}