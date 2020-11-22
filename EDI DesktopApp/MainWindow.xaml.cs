using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using EDI_DesktopApp.EDIServiceRef;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EDI_DesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Test data: {'Type': 'M','Name': 'M_940','Content': [{'Type': 'S','Name': 'W05','Content': [ { 'E': 'N' }, { 'E': '538686' }, { 'E': '' }, { 'E': '001001' }, { 'E': '538686' }]}]}
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var strEDITransaction = tbEdiJson.Text;
            //var json = JsonConvert.DeserializeObject(strEDITransaction);
            dynamic json = JObject.Parse(strEDITransaction);

            using (TranslatorClient EdiService = new TranslatorClient())
            {
                var testOutput = EdiService.GetEDIDocFromJSON(tbEdiJson.Text);
                MessageBox.Show("name = " + json.Name + " = " + testOutput);
            }

        }

    }
}
