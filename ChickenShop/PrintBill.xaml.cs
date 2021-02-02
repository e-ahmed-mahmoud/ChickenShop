using System;
using System.Collections.Generic;
//using System.Drawing;
//using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;



namespace ChickenShop
{
    /// <summary>
    /// Interaction logic for PrintedBill.xaml
    /// </summary>
    public partial class PrintBill : Window , IDisposable
    {

        private BillData bill = new BillData();
        
        public PrintBill(BillData billData)
        {
            InitializeComponent();
            bill = billData;
        }

        public void Dispose()
        {
            this.Close();
        }

        public void SetBill()
        {
            PrintDialog printDialog = new PrintDialog();

            FlowDocument doc = new FlowDocument();
            int FontSize = 10;

            const double width = 3.14;
            const double height = 11.69;

            System.Drawing.Printing.PrinterSettings ps = new System.Drawing.Printing.PrinterSettings();


            var pageSize = new System.Windows.Size(width,height); // A5 page, at 96 dpi
          //  var pageSize =System.Drawing.Printing.PaperKind.A6;

            

            doc.FlowDirection = FlowDirection.RightToLeft;
            doc.Name = "FlowDoc";
            doc.ColumnWidth = printDialog.PrintableAreaWidth;
            doc.PagePadding = new Thickness(0.0);

            Paragraph title = new Paragraph(new Run(" الهدى لجزارة الدواجن "));
            title.FontFamily = new FontFamily("Arial");
            title.FontStyle = FontStyles.Normal;
            title.FontWeight = FontWeights.UltraBold;
            title.FontSize = FontSize*2;
            title.TextAlignment = TextAlignment.Center;
            //title.Margin.Equals(1);
            title.Padding = new Thickness(0.0);
            doc.Blocks.Add(title);

            string bNumber = "";
            Paragraph billNumber = new Paragraph(new Run ("  " + "رقم الفاتورة " + " \t\t\t " + bNumber + "#"));
            billNumber.FontStyle = FontStyles.Normal;
            billNumber.FontWeight = FontWeights.UltraBold;
            billNumber.FontSize = FontSize;
            billNumber.Padding = new Thickness(0.0);
            doc.Blocks.Add(billNumber);

            Paragraph Billtime = new Paragraph(new Run("  "+ "التاريخ" + "\t" + 
                DateTime.Now.ToShortDateString() + "\t\t\t\t" + " الوقت " + DateTime.Now.ToShortTimeString()));
            Billtime.FontStyle = FontStyles.Normal;
            Billtime.FontWeight = FontWeights.UltraBold;
            Billtime.FontSize = FontSize;
            Billtime.Padding = new Thickness(0.0);
            Billtime.FontFamily = new FontFamily("Arial");
            doc.Blocks.Add(Billtime);

            string client = "  "+"اسم العميل " + "\t" + "name" + "\n" +"  "+ "الموبايل" 
                + "\t\t"+ "phone "+ "\t\t\t\t" + "العنوان " + "adress"; 
            Paragraph clientData = new Paragraph(new Run(client));
            clientData.FontStyle = FontStyles.Normal;
            clientData.FontWeight = FontWeights.UltraBold;
            clientData.FontSize = FontSize;
            clientData.Padding = new Thickness(0.0);
            clientData.FontFamily = new FontFamily("Arial");
            doc.Blocks.Add(clientData);

            var table = new Table();
            table.FontWeight = FontWeights.Bold;
            
            #region table
            //// Set some global formatting properties for the table.
            ////table.CellSpacing = 10;
            //table.Background = Brushes.White;
            //// Create 6 columns and add them to the table's Columns collection.

            ////TableColumn tableColumn = new TableColumn();
            ////tableColumn.Width = new GridLength(tableColumn.Width.Value * 2) ;
            ////table.Columns.Add(tableColumn);
            //int numberOfColumns = 7 ;

            //for (int x = 0; x < numberOfColumns; x++)
            //{
            //    table.Columns.Add(new TableColumn());
            //    // Set alternating background colors for the middle colums.
            //    //if (x % 2 == 0)
            //    //    table.Columns[x].Background = Brushes.Beige;
            //    //else
            //    //    table.Columns[x].Background = Brushes.LightSteelBlue;

            //}
            //// Set alternating background colors for the middle colums.
            ////if (x % 2 == 0)
            ////    table.Columns[x].Background = Brushes.Beige;
            ////else
            ////    table.Columns[x].Background = Brushes.LightSteelBlue;


            //// Create and add an empty TableRowGroup to hold the table's Rows.
            //table.RowGroups.Add(new TableRowGroup());

            //// Add the first (title) row.
            //table.RowGroups[0].Rows.Add(new TableRow());

            //// Alias the current working row for easy reference.
            //TableRow currentRow = table.RowGroups[0].Rows[0];

            //// Global formatting for the title row.
            //currentRow.Background = Brushes.Silver;
            //currentRow.FontSize = 40;
            //currentRow.FontWeight = System.Windows.FontWeights.Bold;

            //// Add the header row with content,
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("2004 Sales Project"))));
            //// and set the row to span all 6 columns.
            //currentRow.Cells[0].ColumnSpan = 6;

            //// Add the second (header) row.
            //table.RowGroups[0].Rows.Add(new TableRow());
            //currentRow = table.RowGroups[0].Rows[1];

            //// Global formatting for the header row.
            //currentRow.FontSize = 18;
            //currentRow.FontWeight = FontWeights.Bold;

            //// Add cells with content to the second row.
            //var ce = new TableCell(new Paragraph(new Run("Product for test")));
            //currentRow.Cells.Add(ce);
            //currentRow.Cells[0].ColumnSpan=2;


            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Quarter 1"))));
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Quarter 2"))));
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Quarter 3"))));

            //// Add the third row.
            //table.RowGroups[0].Rows.Add(new TableRow());
            //currentRow = table.RowGroups[0].Rows[2];

            //// Global formatting for the row.
            //currentRow.FontSize = 12;
            //currentRow.FontWeight = FontWeights.Normal;

            //// Add cells with content to the third row.
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("Widgets"))));
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$50,000"))));
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$55,000"))));
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$60,000"))));
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$65,000"))));
            //currentRow.Cells.Add(new TableCell(new Paragraph(new Run("$230,000"))));

            // Bold the first cell.
            //currentRow.Cells[0].FontWeight = FontWeights.Bold;

            //            doc.ColumnGap = 2.58;
            // ...and add it to the FlowDocument Blocks collection.
            #endregion

            int columnsNumber = 7;                  //Set columns number
            for (int i = 0; i < columnsNumber; i++)
            {
                table.Columns.Add(new TableColumn());
            }

            //add first Header
            table.RowGroups.Add(new TableRowGroup());           //create table rowGroups in first dimension
            table.RowGroups[0].Rows.Add(new TableRow());        // adding tableRow in RowGruops 

            TableRow tableRowPtr = table.RowGroups[0].Rows[0];      //set Row pointer to current position
            tableRowPtr.Cells.Add(new TableCell(new Paragraph(new Run("\t الصنف"))));
            tableRowPtr.Cells[0].ColumnSpan = 2;
            tableRowPtr.Cells.Add(new TableCell(new Paragraph(new Run("الكمية"))));
            tableRowPtr.Cells.Add(new TableCell(new Paragraph(new Run("سعر الوحدة"))));
            tableRowPtr.Cells.Add(new TableCell(new Paragraph(new Run("السعر "))));


            doc.Blocks.Add(table);

            /*
            //string strFigure = "A Figure embeds content into flow content with" +
            //       " placement properties that can be customized" +
            //       " independently from the primary content flow";
            //string strOther = "Lorem ipsum dolor sit amet, consectetuer adipiscing" +
            //                  " elit, sed diam nonummy nibh euismod tincidunt ut laoreet" +
            //                  " dolore magna aliquam erat volutpat. Ut wisi enim ad" +
            //                  " minim veniam, quis nostrud exerci tation ullamcorper" +
            //                  " suscipit lobortis nisl ut aliquip ex ea commodo consequat." +
            //                  " Duis autem vel eum iriure.";

            // Create a Figure and assign content and layout properties to it.
            //Figure myFigure = new Figure();
            //myFigure.Width = new FigureLength(300);
            //myFigure.Height = new FigureLength(100);
            //myFigure.Background = Brushes.GhostWhite;
            //myFigure.HorizontalAnchor = FigureHorizontalAnchor.PageLeft;
            //Paragraph myFigureParagraph = new Paragraph(new Run(strOther));
            //myFigureParagraph.FontStyle = FontStyles.Italic;
            //myFigureParagraph.Background = Brushes.Beige;
            //myFigureParagraph.Foreground = Brushes.DarkGreen;
            //myFigure.Blocks.Add(myFigureParagraph);

            doc.Blocks.Add(myFigureParagraph);
            */
            IDocumentPaginatorSource idpSource = doc;
            idpSource.DocumentPaginator.PageSize = pageSize;
            MessageBox.Show(printDialog.ToString());
            MessageBox.Show(pageSize.Height.ToString() + pageSize.Width.ToString() );
            this.ShowDialog();
            printDialog.PrintDocument(idpSource.DocumentPaginator, "Hello WPF Printing.");
            printDialog.PrintQueue.Dispose();
            this.Dispose();

        }
    }
}
