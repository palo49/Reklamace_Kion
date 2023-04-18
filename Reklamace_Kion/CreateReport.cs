using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

namespace Reklamace_Kion
{
    internal class CreateReport
    {
        public void CreateDocument(string MyName, string FN, string LN, string CLM)
        {
            try
            {
                List<string> DataMain = new List<string>();
                List<int> DataBB = new List<int>();

                SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace");
                
                conn.Open();

                SqlCommand cmdDataMain = new SqlCommand("SELECT Contact, PN_Claimed_Component, Date_Of_Saft_Acceptance, Customer_Require, PN_Battery, SN_Battery FROM DataMain WHERE CLM='" + CLM + "'", conn);
                SqlDataReader readerDataMain = cmdDataMain.ExecuteReader();
                while (readerDataMain.Read())
                {
                    for (int x = 0; x < readerDataMain.FieldCount; x++)
                    {
                        DataMain.Add(readerDataMain.GetString(x));
                    }
                }
                readerDataMain.Close();

                SqlCommand cmdDataBB = new SqlCommand("SELECT Saft_Fault_Code_1, Kion_Fault_Code_1, Kion_DTC_1, Saft_Fault_Code_2, Kion_Fault_Code_2, Kion_DTC_2, Saft_Fault_Code_3, Kion_Fault_Code_3, Kion_DTC_3, Saft_Fault_Code_4, Kion_Fault_Code_4, Kion_DTC_4, Saft_Fault_Code_5, Kion_Fault_Code_5, Kion_DTC_5, Saft_Fault_Code_6, Kion_Fault_Code_6, Kion_DTC_6, Saft_Fault_Code_7, Kion_Fault_Code_7, Kion_DTC_7, Saft_Fault_Code_8, Kion_Fault_Code_8, Kion_DTC_8, Saft_Fault_Code_9, Kion_Fault_Code_9, Kion_DTC_9, Saft_Fault_Code_10, Kion_Fault_Code_10, Kion_DTC_10, Saft_Fault_Code_11, Kion_Fault_Code_11, Kion_DTC_11, Saft_Fault_Code_12, Kion_Fault_Code_12, Kion_DTC_12 FROM DataAnalysis_BB WHERE CLM='" + CLM + "'", conn);
                SqlDataReader readerDataBB = cmdDataBB.ExecuteReader();
                while (readerDataBB.Read())
                {
                    for (int x = 0; x < readerDataBB.FieldCount; x++)
                    {
                        DataBB.Add(readerDataBB.GetInt32(x));
                    }
                }
                readerDataBB.Close();

                conn.Close();


                Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
                winword.ShowAnimation = false;
                winword.Visible = false;
                object missing = System.Reflection.Missing.Value;

                Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
                {
                    Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);

                    headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdGray25;

                    Table tableHeader = document.Tables.Add(headerRange, 1, 2, ref missing, ref missing);

                    List<string> th = new List<string> { CLM };
                    List<string> thData = new List<string> { "" };

                    int ith = 0;
                    tableHeader.Borders.Enable = 0;
                    foreach (Row row in tableHeader.Rows)
                    {
                        row.Height = 20;
                        row.Cells[1].Range.Text = th[ith];
                        row.Cells[2].Range.Text = thData[ith];
                        ith++;

                        foreach (Cell cell in row.Cells)
                        {
                            if (cell.ColumnIndex == 1)
                            {
                                cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalBottom;
                                cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                            }
                            else
                            {
                                cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalBottom;
                                cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                            }
                        }
                    }
                }

               
                winword.Selection.GoTo(Microsoft.Office.Interop.Word.WdGoToItem.wdGoToPage, Microsoft.Office.Interop.Word.WdGoToDirection.wdGoToFirst, 1, missing);

                var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                var logoimage = Path.Combine(outPutDirectory, "img\\Saft_logo_new.png");

                Microsoft.Office.Interop.Word.Paragraph paraImg = document.Content.Paragraphs.Add(ref missing);
                paraImg.Range.InsertParagraphAfter();
                Table tableLogo = document.Tables.Add(paraImg.Range, 1, 2, ref missing, ref missing);

                tableLogo.Borders.Enable = 0;
                foreach (Row row in tableLogo.Rows)
                {
                    row.Height = 50;
                    row.Cells[1].Range.InlineShapes.AddPicture(logoimage);
                    row.Cells[2].Range.Text = "TECHNICAL EVALUATION";

                    foreach (Cell cell in row.Cells)
                    {
                        if (cell.ColumnIndex == 1)
                        {
                            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalBottom;
                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        }
                        else
                        {
                            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalBottom;
                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                            cell.Range.Font.Size = 20;
                        }
                    }
                }



                Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);;
                //para1.Range.InsertParagraphAfter();

                Table firstTable = document.Tables.Add(para1.Range, 5, 2, ref missing, ref missing);

                List<string> ft = new List<string> { "Department:", "Date:", "Issued by:", "Addresse:", "Subject:", "SAFT ref.:" };
                List<string> ftData = new List<string> { "PDC", DateTime.Now.ToString("dd.MM.yyyy"), FN + " " + LN, DataMain[0], DataMain[1], CLM };

                int i = 0;
                firstTable.Borders.Enable = 1;
                firstTable.Borders.OutsideColor = WdColor.wdColorGray25;
                firstTable.Borders.InsideColor = WdColor.wdColorGray25;
                foreach (Row row in firstTable.Rows)
                {
                    row.Height = 30;
                    row.Cells[1].Range.Font.Bold = 1;
                    row.Cells[1].Range.Text = ft[i];
                    row.Cells[2].Range.Text = ftData[i];
                    i++;

                    foreach (Cell cell in row.Cells)
                    {                             
                        if (cell.ColumnIndex == 1)
                        {
                            //Center alignment for the Header cells  
                            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalBottom;
                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        }
                        else
                        {
                            //Center alignment for the Header cells  
                            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalBottom;
                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        }
                    }
                }
                firstTable.AllowAutoFit = true;
                Microsoft.Office.Interop.Word.Column firstCol = firstTable.Columns[1];
                firstCol.AutoFit(); // force fit sizing
                Single firstColAutoWidth = firstCol.Width; // store autofit width
                firstTable.AutoFitBehavior(Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitWindow); // fill page width
                firstCol.SetWidth(firstColAutoWidth, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustFirstColumn);

                Microsoft.Office.Interop.Word.Paragraph para2 = document.Content.Paragraphs.Add(ref missing);
                para2.Range.Font.Bold = 1;
                para2.Range.Font.Size = 18;
                para2.Range.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                para2.Range.Text = "\n1 Claim description";
                para2.Range.InsertParagraphAfter();

                Microsoft.Office.Interop.Word.Paragraph para3 = document.Content.Paragraphs.Add(ref missing); ;
                Table table2 = document.Tables.Add(para3.Range, 1, 2, ref missing, ref missing);

                List<string> t2 = new List<string> { "Arrived at SAFT:" };
                List<string> t2Data = new List<string> { DataMain[2] };

                int i2 = 0;
                table2.Borders.Enable = 0;
                foreach (Row row in table2.Rows)
                {
                    row.Height = 30;
                    row.Cells[1].Range.Text = t2[i2];
                    row.Cells[2].Range.Text = t2Data[i2];
                    i2++;

                    foreach (Cell cell in row.Cells)
                    {
                        if (cell.ColumnIndex == 1)
                        {
                            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalBottom;
                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        }
                        else
                        { 
                            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalBottom;
                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                        }
                    }
                }

                Microsoft.Office.Interop.Word.Paragraph para4 = document.Content.Paragraphs.Add(ref missing);
                para4.Range.Font.Bold = 1;
                para4.Range.Font.Size = 14;
                para4.Range.Text = "\nCustomer description:";
                para4.Range.InsertParagraphAfter();

                Microsoft.Office.Interop.Word.Paragraph para5 = document.Content.Paragraphs.Add(ref missing);
                para5.Range.Text = DataMain[3];
                para5.Range.InsertParagraphAfter();

                Microsoft.Office.Interop.Word.Paragraph para6 = document.Content.Paragraphs.Add(ref missing);
                para6.Range.Font.Bold = 1;
                para6.Range.Font.Size = 14;
                para6.Range.Text = "\nSubject:";
                para6.Range.InsertParagraphAfter();

                Microsoft.Office.Interop.Word.Paragraph para7 = document.Content.Paragraphs.Add(ref missing); ;
                Table table3 = document.Tables.Add(para7.Range, 2, 2, ref missing, ref missing);

                List<string> t3 = new List<string> { "Battery PN:", "Battery SN:" };
                List<string> t3Data = new List<string> { DataMain[4], DataMain[5] };

                int i3 = 0;
                table3.Borders.Enable = 1;
                table3.Borders.OutsideColor = WdColor.wdColorGray25;
                table3.Borders.InsideColor = WdColor.wdColorGray25;
                foreach (Row row in table3.Rows)
                {
                    row.Height = 30;
                    row.Cells[1].Range.Text = t3[i3];
                    row.Cells[2].Range.Text = t3Data[i3];
                    i3++;

                    foreach (Cell cell in row.Cells)
                    {
                        if (cell.ColumnIndex == 1)
                        {
                            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalBottom;
                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                            cell.Shading.BackgroundPatternColor = WdColor.wdColorGray15;
                        }
                        else
                        {
                            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalBottom;
                            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                        }
                    }
                }
                table3.AllowAutoFit = true;
                Microsoft.Office.Interop.Word.Column firstColt3 = table3.Columns[1];
                firstColt3.AutoFit(); // force fit sizing
                Single firstColAutoWidtht3 = firstColt3.Width; // store autofit width
                table3.AutoFitBehavior(Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitWindow); // fill page width
                firstColt3.SetWidth(firstColAutoWidtht3, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustFirstColumn);

                Microsoft.Office.Interop.Word.Paragraph para8 = document.Content.Paragraphs.Add(ref missing);
                para8.Range.Font.Bold = 1;
                para8.Range.Font.Size = 14;
                para8.Range.Text = "\nDetailed description of BMS received:";
                para8.Range.InsertParagraphAfter();

                Microsoft.Office.Interop.Word.Paragraph para9 = document.Content.Paragraphs.Add(ref missing);
                para9.Range.Text = "The  arrived at SAFT in order.\nThe delivery date of the BMS was ????????\nOther components were not included.\nThe inviolability stickers were not broken down.\nThe BMS was not possible to switch on.\n";
                para9.Range.InsertParagraphAfter();

                document.Words.Last.InsertBreak(Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak);
                winword.Selection.GoTo(Microsoft.Office.Interop.Word.WdGoToItem.wdGoToPage, Microsoft.Office.Interop.Word.WdGoToDirection.wdGoToFirst, 2, missing);

                Microsoft.Office.Interop.Word.Paragraph para10 = document.Content.Paragraphs.Add(ref missing);
                para10.Range.Font.Bold = 1;
                para10.Range.Font.Size = 18;
                para10.Range.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                para10.Range.Text = "2 Investigation";
                para10.Range.InsertParagraphAfter();

                Microsoft.Office.Interop.Word.Paragraph para11 = document.Content.Paragraphs.Add(ref missing);
                para11.Range.Text = "The BMS arrived at SAFT for analysis. Cannot turn on during BMS test, see picture 1 These errors have been discovered, see.error in blackbox. An overvoltage can cause the truck to be over 209. For this reason, the D78,D76 and F1 components were destroyed. The cause of the malfunctionning battery was a defective BMS due to external overvoltage from truck or charger.\n";
                para11.Range.InsertParagraphAfter();

                Microsoft.Office.Interop.Word.Paragraph para12 = document.Content.Paragraphs.Add(ref missing);
                para12.Range.Font.Bold = 1;
                para12.Range.Font.Size = 14;
                para12.Range.Text = "\nError in blackbox:";
                para12.Range.InsertParagraphAfter();

                Microsoft.Office.Interop.Word.Paragraph para13 = document.Content.Paragraphs.Add(ref missing); ;
                Table table4 = document.Tables.Add(para13.Range, 13, 4, ref missing, ref missing);

                List<string> t4 = new List<string> { "SAFT FC", "Kion FC", "Kion DTC", "Description" };
                List<string> t4Data = new List<string> { "000", "000", "000", "some text here..." };

                int i4 = 0;
                int i4_2 = 0;
                table4.Borders.Enable = 1;
                table4.Borders.OutsideColor = WdColor.wdColorGray25;
                table4.Borders.InsideColor = WdColor.wdColorGray25;
                foreach (Row row in table4.Rows)
                {
                    row.Height = 20;

                    foreach (Cell cell in row.Cells)
                    {
                        if(cell.RowIndex == 1)
                        {
                            cell.Shading.BackgroundPatternColor = WdColor.wdColorGray15;
                            cell.Range.Text = t4[i4];
                            if (cell.ColumnIndex <= 3)
                            {
                                cell.Range.Orientation = WdTextOrientation.wdTextOrientationUpward;
                            }
                            i4++;
                        }
                        else
                        {
                            if (DataBB.Count > 0)
                            {
                                if (cell.ColumnIndex < 4)
                                {
                                    cell.Range.Text = DataBB[i4_2].ToString();
                                    i4_2++;
                                }
                                else
                                {
                                    cell.Range.Text = String.Empty;
                                }
                            }
                        }

                        cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    }
                    i4 = 0;
                }
                table4.AllowAutoFit = true;

                for (int y = 0; y < 3; y++)
                {
                    Microsoft.Office.Interop.Word.Column firstColt4 = table4.Columns[y + 1];
                    firstColt4.AutoFit(); // force fit sizing
                    Single firstColAutoWidtht4 = firstColt4.Width; // store autofit width
                    table4.AutoFitBehavior(Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitWindow); // fill page width
                    firstColt4.SetWidth(firstColAutoWidtht4, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustFirstColumn);
                }
                //table4.Columns[4].SetWidth(270, WdRulerStyle.wdAdjustSameWidth);


                Microsoft.Office.Interop.Word.Paragraph para14 = document.Content.Paragraphs.Add(ref missing);
                para14.Range.Font.Bold = 1;
                para14.Range.Font.Size = 14;
                para14.Range.Text = "\nList of tests:";
                para14.Range.InsertParagraphAfter();

                Microsoft.Office.Interop.Word.Paragraph para15 = document.Content.Paragraphs.Add(ref missing);
                Table table5 = document.Tables.Add(para15.Range, 3, 2, ref missing, ref missing);

                List<string> t5 = new List<string> { "Test performed", "Result" };
                List<string> t5Data = new List<string> { "Diagnostic", "BlackBox" };

                int i5 = 0;
                table5.Borders.Enable = 1;
                table5.Borders.OutsideColor = WdColor.wdColorGray25;
                table5.Borders.InsideColor = WdColor.wdColorGray25;
                foreach (Row row in table5.Rows)
                {
                    row.Height = 30;
                    if (row.Index == 1)
                    {
                        row.Cells[1].Range.Text = t5[0];
                        row.Cells[2].Range.Text = t5[1];
                    }
                    else if (row.Index <= 3)
                    {
                        row.Cells[1].Range.Text = t5Data[i5];
                        i5++;
                    }
                    
                    foreach (Cell cell in row.Cells)
                    {
                        if (cell.RowIndex == 1)
                        {
                            cell.Shading.BackgroundPatternColor = WdColor.wdColorGray15;
                        }
                        cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalBottom;
                        cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                    }
                }
                table5.AllowAutoFit = true;
                Microsoft.Office.Interop.Word.Column firstColt5 = table5.Columns[1];
                firstColt5.AutoFit(); // force fit sizing
                Single firstColAutoWidtht5 = firstColt5.Width; // store autofit width
                table5.AutoFitBehavior(Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitWindow); // fill page width
                firstColt5.SetWidth(firstColAutoWidtht5, Microsoft.Office.Interop.Word.WdRulerStyle.wdAdjustFirstColumn);

                document.Words.Last.InsertBreak(Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak);
                winword.Selection.GoTo(Microsoft.Office.Interop.Word.WdGoToItem.wdGoToPage, Microsoft.Office.Interop.Word.WdGoToDirection.wdGoToFirst, 3, missing);

                Microsoft.Office.Interop.Word.Paragraph para16 = document.Content.Paragraphs.Add(ref missing);
                para16.Range.Font.Bold = 1;
                para16.Range.Font.Size = 18;
                para16.Range.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                para16.Range.Text = "3 Conclusion";
                para16.Range.InsertParagraphAfter();

                Microsoft.Office.Interop.Word.Paragraph para17 = document.Content.Paragraphs.Add(ref missing);
                para17.Range.Text = "Based on these facts, we dont accept the claim BMS.\n";
                para17.Range.InsertParagraphAfter();


                //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                //saveFileDialog1.InitialDirectory = @"C:\";
                //saveFileDialog1.Title = "Ulož report do...";
                //saveFileDialog1.CheckPathExists = true;
                //saveFileDialog1.DefaultExt = "docx";
                //saveFileDialog1.Filter = "Word file (*.docx)|*.docx";
                //saveFileDialog1.RestoreDirectory = false;
                //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                //{
                //    //Save the document  
                //    object filename = saveFileDialog1.FileName;
                //    document.SaveAs2(ref filename);
                //    document.Close(ref missing, ref missing, ref missing);
                //    document = null;
                //    winword.Quit(ref missing, ref missing, ref missing);
                //    winword = null;
                //}

                //Save the document  
                string now = DateTime.Now.ToString("yyMMddhhmms");
                string filename = "Report_" + CLM + "_" + now;
                object path = @"";
                bool pathExist = true;
                if (Directory.Exists(@"\\cz-ras-fs2\Applications\KION\10_Reklamace\" + CLM))
                {
                    path = @"\\cz-ras-fs2\Applications\KION\10_Reklamace\" + CLM + @"\" + filename;
                }
                else if (Directory.Exists(@"\\cz-ras-fs2\Applications\KION\10_Reklamace\KionApp\" + CLM))
                {
                    path = @"\\cz-ras-fs2\Applications\KION\10_Reklamace\KionApp\" + CLM + @"\" + filename;
                }
                else
                {
                    MessageBox.Show("Složka k tomuto CLM neexistuje. Můžete umístění vybrat manuálně.");
                    pathExist = false;
                }

                if (pathExist)
                {
                    document.SaveAs2(ref path);
                    document.Close(ref missing, ref missing, ref missing);
                    document = null;
                    winword.Quit(ref missing, ref missing, ref missing);
                    winword = null;
                    MessageBox.Show("Hotovo.");
                }
                else
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.InitialDirectory = @"C:\";
                    saveFileDialog1.Title = "Ulož report do...";
                    saveFileDialog1.CheckPathExists = true;
                    saveFileDialog1.DefaultExt = "docx";
                    saveFileDialog1.Filter = "Word file (*.docx)|*.docx";
                    saveFileDialog1.RestoreDirectory = false;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        //Save the document  
                        object filename2 = saveFileDialog1.FileName;
                        document.SaveAs2(ref filename2);
                        document.Close(ref missing, ref missing, ref missing);
                        document = null;
                        winword.Quit(ref missing, ref missing, ref missing);
                        winword = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
