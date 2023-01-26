using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;

namespace Reklamace_Kion
{
    internal class CreateReport
    {
        public void CreateDocument(string MyName, string FN, string LN)
        {
            try
            {
                Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
                winword.ShowAnimation = false;
                winword.Visible = false;
                object missing = System.Reflection.Missing.Value;

                Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                foreach (Microsoft.Office.Interop.Word.Section section in document.Sections)
                {
                    Microsoft.Office.Interop.Word.Range headerRange = section.Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Microsoft.Office.Interop.Word.WdFieldType.wdFieldPage);
                   

                    headerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    headerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                    headerRange.Font.Size = 18;
                    headerRange.Text = "Technical evaluation";
                }

                

                /// Start of page 1

                int col1Width = 200;
                int col2Width = 540 - col1Width;
                int col2StartPos = col1Width + 30;

                Microsoft.Office.Core.MsoTriState borderVisibility = Microsoft.Office.Core.MsoTriState.msoTrue;
                Microsoft.Office.Core.MsoTriState fillVisibility = Microsoft.Office.Core.MsoTriState.msoFalse;

                var txt1 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 80, col1Width, 25);
                txt1.Fill.Visible = fillVisibility;
                txt1.Line.Visible = borderVisibility;
                txt1.TextFrame.TextRange.Text = "Department: ";

                var txt2 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, col2StartPos, 80, col2Width, 25);
                txt2.Fill.Visible = fillVisibility;
                txt2.Line.Visible = borderVisibility;
                txt2.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                txt2.TextFrame.TextRange.Text = "PDC";

                var txt1_2 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 105, col1Width, 25);
                txt1_2.Fill.Visible = fillVisibility;
                txt1_2.Line.Visible = borderVisibility;
                txt1_2.TextFrame.TextRange.Text = "Date: ";

                var txt2_2 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, col2StartPos, 105, col2Width, 25);
                txt2_2.Fill.Visible = fillVisibility;
                txt2_2.Line.Visible = borderVisibility;
                txt2_2.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                txt2_2.TextFrame.TextRange.Text = DateTime.Now.ToString("dd.MM.yyyy");

                var txt3 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 130, col1Width, 25);
                txt3.Fill.Visible = fillVisibility;
                txt3.Line.Visible = borderVisibility;
                txt3.TextFrame.TextRange.Text = "Issued by: ";

                var txt4 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, col2StartPos, 130, col2Width, 25);
                txt4.Fill.Visible = fillVisibility;
                txt4.Line.Visible = borderVisibility;
                txt4.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                txt4.TextFrame.TextRange.Text = FN + " " + LN;

                var txt5 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 155, col1Width, 25);
                txt5.Fill.Visible = fillVisibility;
                txt5.Line.Visible = borderVisibility;
                txt5.TextFrame.TextRange.Text = "Addresse: ";

                var txt6 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, col2StartPos, 155, col2Width, 25);
                txt6.Fill.Visible = fillVisibility;
                txt6.Line.Visible = borderVisibility;
                txt6.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                txt6.TextFrame.TextRange.Text = "contact";

                var txt7 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 180, col1Width, 25);
                txt7.Fill.Visible = fillVisibility;
                txt7.Line.Visible = borderVisibility;
                txt7.TextFrame.TextRange.Text = "Subject: ";

                var txt8 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, col2StartPos, 180, col2Width, 25);
                txt8.Fill.Visible = fillVisibility;
                txt8.Line.Visible = borderVisibility;
                txt8.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                txt8.TextFrame.TextRange.Text = "PN_Claimed_Component";

                var txt9 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 205, col1Width, 25);
                txt9.Fill.Visible = fillVisibility;
                txt9.Line.Visible = borderVisibility;
                txt9.TextFrame.TextRange.Text = "SAFT ref.:";

                var txt10 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, col2StartPos, 205, col2Width, 25);
                txt10.Fill.Visible = fillVisibility;
                txt10.Line.Visible = borderVisibility;
                txt10.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                txt10.TextFrame.TextRange.Text = "CLM";

                var txt11 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 255, 540, 30);
                txt11.Fill.Visible = fillVisibility;
                txt11.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
                txt11.TextFrame.TextRange.Font.Bold = 1;
                txt11.TextFrame.TextRange.Font.Size = 18;
                txt11.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                txt11.TextFrame.TextRange.Text = "1 Claim description";

                var txt12 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 285, col1Width, 25);
                txt12.Fill.Visible = fillVisibility;
                txt12.Line.Visible = borderVisibility;
                txt12.TextFrame.TextRange.Text = "Arrived at SAFT: ";

                var txt13 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, col2StartPos, 285, col2Width, 25);
                txt13.Fill.Visible = fillVisibility;
                txt13.Line.Visible = borderVisibility;
                txt13.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                txt13.TextFrame.TextRange.Text = "Date_of_saft_acceptance";

                var txt14 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 335, 540, 25);
                txt14.Fill.Visible = fillVisibility;
                txt14.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
                txt14.TextFrame.TextRange.Font.Bold = 1;
                txt14.TextFrame.TextRange.Text = "Customer description:";

                var txt15 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 360, 540, 80);
                txt15.Fill.Visible = fillVisibility;
                txt15.Line.Visible = borderVisibility;
                txt15.TextFrame.TextRange.Text = "Customer require...";

                var txt16 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 465, 540, 25);
                txt16.Fill.Visible = fillVisibility;
                txt16.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
                txt16.TextFrame.TextRange.Font.Bold = 1;
                txt16.TextFrame.TextRange.Text = "Subject:";

                var txt17 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 490, 75, 50);
                txt17.Fill.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
                txt17.Line.Visible = borderVisibility;
                txt17.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                txt17.TextFrame.VerticalAnchor = Microsoft.Office.Core.MsoVerticalAnchor.msoAnchorMiddle;
                txt17.TextFrame.MarginTop = 10;
                txt17.TextFrame.TextRange.Text = "Battery";

                var txt18 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 105, 490, 30, 25);
                txt18.Fill.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
                txt18.Line.Visible = borderVisibility;
                txt18.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                txt18.TextFrame.TextRange.Text = "PN:";

                var txt19 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 105, 515, 30, 25);
                txt19.Fill.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
                txt19.Line.Visible = borderVisibility;
                txt19.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                txt19.TextFrame.TextRange.Text = "SN:";

                var txt20 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 135, 490, 435, 25);
                txt20.Fill.Visible = fillVisibility;
                txt20.Line.Visible = borderVisibility;
                txt20.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                txt20.TextFrame.TextRange.Text = "PN_battery";

                var txt21 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 135, 515, 435, 25);
                txt21.Fill.Visible = fillVisibility;
                txt21.Line.Visible = borderVisibility;
                txt21.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
                txt21.TextFrame.TextRange.Text = "SN_battery";

                var txt22 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 555, 540, 25);
                txt22.Fill.Visible = fillVisibility;
                txt22.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
                txt22.TextFrame.TextRange.Font.Bold = 1;
                txt22.TextFrame.TextRange.Text = "Detailed description of BMS received:";

                var txt23 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 580, 540, 80);
                txt23.Fill.Visible = fillVisibility;
                txt23.Line.Visible = borderVisibility;
                txt23.TextFrame.TextRange.Text = "Some text here...";

                document.Words.Last.InsertBreak(Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak);

                /// End of page 1
                /// Start of page 2

                winword.Selection.GoTo(Microsoft.Office.Interop.Word.WdGoToItem.wdGoToPage, Microsoft.Office.Interop.Word.WdGoToDirection.wdGoToFirst, 2, missing);

                var txt24 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 80, 540, 30);
                txt24.Fill.Visible = fillVisibility;
                txt24.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
                txt24.TextFrame.TextRange.Font.Bold = 1;
                txt24.TextFrame.TextRange.Font.Size = 18;
                txt24.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                txt24.TextFrame.TextRange.Text = "2 Investigation";

                var txt24_1 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 110, 540, 215);
                txt24_1.Fill.Visible = fillVisibility;
                txt24_1.Line.Visible = borderVisibility;
                txt24_1.TextFrame.TextRange.Text = "Some text here...";

                var txt25 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 350, 540, 25);
                txt25.Fill.Visible = fillVisibility;
                txt25.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
                txt25.TextFrame.TextRange.Font.Bold = 1;
                txt25.TextFrame.TextRange.Text = "Error in blackbox:";

                var txt26 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 375, 40, 75);
                txt26.Fill.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
                txt26.Line.Visible = borderVisibility;
                txt26.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                txt26.TextFrame.TextRange.Orientation = WdTextOrientation.wdTextOrientationUpward;
                txt26.TextFrame.MarginLeft = 15;
                txt26.TextFrame.TextRange.Text = "SAFT FC";

                var txt27 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 70, 375, 40, 75);
                txt27.Fill.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
                txt27.Line.Visible = borderVisibility;
                txt27.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                txt27.TextFrame.TextRange.Orientation = WdTextOrientation.wdTextOrientationUpward;
                txt27.TextFrame.MarginLeft = 15;
                txt27.TextFrame.TextRange.Text = "Kion FC";

                var txt28 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 110, 375, 40, 75);
                txt28.Fill.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
                txt28.Line.Visible = borderVisibility;
                txt28.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                txt28.TextFrame.TextRange.Orientation = WdTextOrientation.wdTextOrientationUpward;
                txt28.TextFrame.MarginLeft = 15;
                txt28.TextFrame.TextRange.Text = "Kion DTC";

                var txt29 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 375, 420, 75);
                txt29.Fill.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
                txt29.Line.Visible = borderVisibility;
                txt29.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                txt29.TextFrame.VerticalAnchor = Microsoft.Office.Core.MsoVerticalAnchor.msoAnchorMiddle;
                txt29.TextFrame.MarginTop = 10;
                txt29.TextFrame.TextRange.Text = "Description";

                var txt30 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 450, 40, 25);
                txt30.Fill.Visible = fillVisibility;
                txt30.Line.Visible = borderVisibility;
                txt30.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                txt30.TextFrame.TextRange.Text = "000";

                var txt31 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 70, 450, 40, 25);
                txt31.Fill.Visible = fillVisibility;
                txt31.Line.Visible = borderVisibility;
                txt31.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                txt31.TextFrame.TextRange.Text = "000";

                var txt32 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 110, 450, 40, 25);
                txt32.Fill.Visible = fillVisibility;
                txt32.Line.Visible = borderVisibility;
                txt32.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                txt32.TextFrame.TextRange.Text = "000";

                var txt33 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 150, 450, 420, 25);
                txt33.Fill.Visible = fillVisibility;
                txt33.Line.Visible = borderVisibility;
                txt33.TextFrame.TextRange.Text = "Some text here...";

                var txt34 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 500, 540, 25);
                txt34.Fill.Visible = fillVisibility;
                txt34.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
                txt34.TextFrame.TextRange.Font.Bold = 1;
                txt34.TextFrame.TextRange.Text = "List of tests:";

                var txt35 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 525, col1Width, 25);
                txt35.Fill.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
                txt35.Line.Visible = borderVisibility;
                txt35.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                txt35.TextFrame.TextRange.Text = "Test performed";

                var txt36 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, col2StartPos, 525, col2Width, 25);
                txt36.Fill.Visible = Microsoft.Office.Core.MsoTriState.msoTrue;
                txt36.Line.Visible = borderVisibility;
                txt36.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                txt36.TextFrame.TextRange.Text = "Result";

                var txt37 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 550, col1Width, 25);
                txt37.Fill.Visible = fillVisibility;
                txt37.Line.Visible = borderVisibility;
                txt37.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                txt37.TextFrame.TextRange.Text = "Diagnostic";

                var txt38 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, col2StartPos, 550, col2Width, 25);
                txt38.Fill.Visible = fillVisibility;
                txt38.Line.Visible = borderVisibility;
                txt38.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                var txt39 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 575, col1Width, 25);
                txt39.Fill.Visible = fillVisibility;
                txt39.Line.Visible = borderVisibility;
                txt39.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                txt39.TextFrame.TextRange.Text = "BlackBox";

                var txt40 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, col2StartPos, 575, col2Width, 25);
                txt40.Fill.Visible = fillVisibility;
                txt40.Line.Visible = borderVisibility;
                txt40.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                document.Words.Last.InsertBreak(Microsoft.Office.Interop.Word.WdBreakType.wdPageBreak);

                /// Ënd of page 2
                /// Start of page 3

                winword.Selection.GoTo(Microsoft.Office.Interop.Word.WdGoToItem.wdGoToPage, Microsoft.Office.Interop.Word.WdGoToDirection.wdGoToFirst, 3, missing);

                var txt41 = document.Shapes.AddTextbox(Microsoft.Office.Core.MsoTextOrientation.msoTextOrientationHorizontal, 30, 80, 540, 30);
                txt41.Fill.Visible = fillVisibility;
                txt41.Line.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
                txt41.TextFrame.TextRange.Font.Bold = 1;
                txt41.TextFrame.TextRange.Font.Size = 18;
                txt41.TextFrame.TextRange.Paragraphs.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                txt41.TextFrame.TextRange.Text = "3 Conclusion";

                /// End of page 3

                //Add the footers into the document  
                int pageNum = 1;
                foreach (Microsoft.Office.Interop.Word.Section wordSection in document.Sections)
                {
                    //Get the footer range and add the footer details.  
                    Microsoft.Office.Interop.Word.Range footerRange = wordSection.Footers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    footerRange.Font.ColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdBlack;
                    footerRange.Font.Size = 10;
                    footerRange.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    footerRange.Text = "Page " + pageNum.ToString();
                    pageNum++;
                }

                //Create a 5X5 table and insert some dummy record  
                //Table firstTable = document.Tables.Add(para1.Range, 5, 5, ref missing, ref missing);

                //firstTable.Borders.Enable = 1;
                //foreach (Row row in firstTable.Rows)
                //{
                //    foreach (Cell cell in row.Cells)
                //    {
                //        //Header row  
                //        if (cell.RowIndex == 1)
                //        {
                //            cell.Range.Text = "Column " + cell.ColumnIndex.ToString();
                //            cell.Range.Font.Bold = 1;
                //            //other format properties goes here  
                //            cell.Range.Font.Name = "verdana";
                //            cell.Range.Font.Size = 10;
                //            //cell.Range.Font.ColorIndex = WdColorIndex.wdGray25;                              
                //            cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                //            //Center alignment for the Header cells  
                //            cell.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                //            cell.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;

                //        }
                //        //Data row  
                //        else
                //        {
                //            cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
                //        }
                //    }
                //}

                //Save the document  
                object filename = @"C:\Users\wantulp\Desktop\Test\temp1.docx";
                document.SaveAs2(ref filename);
                document.Close(ref missing, ref missing, ref missing);
                document = null;
                winword.Quit(ref missing, ref missing, ref missing);
                winword = null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
