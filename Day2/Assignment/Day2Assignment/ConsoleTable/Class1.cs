using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;

namespace ConsoleTable
{
    public class Table
    {
        public int tableWidth;
        public static int rowSize = 0;
        public static int colSize = 0;
        List<string[]> list = new List<string[]>();
        List<int> basicData = new List<int>();
        List<string> cls = new List<string>();
        public Table(int tableWidth)
        {
            this.tableWidth = tableWidth;
        }
        public void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public void AddInRow(params string[] columns)
        {
            rowSize = columns.Length;
            list.Add(columns);
            cls = new List<string>(columns);
            colSize++;
        }
        public void display()
        {
            foreach (var item in list)
            {
                foreach (var i in item)
                {
                    Console.Write(i+":"+i.Length+" ");
                    basicData.Add(i.Length);
                }
                Console.WriteLine();
            }
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"Row Size : {rowSize}\nColumn Size : {colSize}");
            Console.WriteLine("---------------------------------------------------");
            foreach (var item in basicData)
            {
                Console.WriteLine(item);

            }
        }

        public void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        public string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}

