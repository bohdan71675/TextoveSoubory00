using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Soubory
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        //Pro práci se soubory v CSharp vždy potřebujeme nějaký stream.

        //Textový soubor je speciální typ souboru, kde jsou znaky uspořádány do řádků (pomocí řídících znaků CR a LF)
        //Textové soubory můžeme zpracovávat obecně, jako kterýkoliv jiný soubor, ale pokud chceme
        //zpracovávat text, práci nám usnadní použití speciálních streamů určených právě jen pro textové soubory: 
        //          StreamWriter 
        //          StreamReader
        
        //Textové soubory lze zpracovávat jedině sekvenčně - od začátku do konce, při zpracování se nelze v souboru vracet.
        //Proto můžeme do textového souboru buďto zapisovat nebo z něj číst. Nelze obojí současně.
        private void button1_Click(object sender, EventArgs e)
        {
            //Pro zápis do textového souboru použijeme třídu StreamWriter
            //- slouží pro otevření konkrétního textového souboru (pokud neexistuje - vytvoří se)
            //  a má metody pro zápis do textového souboru (Write a WriteLine) 

            StreamWriter streamWriter = new StreamWriter("Text.txt");
            streamWriter.WriteLine("Prvni");
            streamWriter.WriteLine("Druhy");
            streamWriter.WriteLine("Brenek je fasista");
            streamWriter.Write('A');
            streamWriter.Write("***");
            streamWriter.Write('X');
            streamWriter.WriteLine();   // ODRADKOVANI
            streamWriter.WriteLine();
            streamWriter.WriteLine("Konec");

            //streamWriter.Flush();
            streamWriter.Close();               //   MUST DO THIS !!!!!!!!!!!!!!!!!!!!!!!!!
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter("Text.txt",true);
            streamWriter.WriteLine("xxxxxxxxxxxxx");

            streamWriter.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Přečte textový soubor po řádcích 
            //a každý přečtený řádek zobrazí v listBox1

            listBox1.Items.Clear();
            StreamReader streamReader = new StreamReader("Text.txt");
            //while (!streamReader.EndOfStream)
            //{
            //    string text = streamReader.ReadLine();       //// ZOBRAZI CELY text v listbox 
            //    listBox1.Items.Add(text);
            //}
            while (!streamReader.EndOfStream)
            {
                char c = (char)streamReader.Read();         // ZOBRAZI text PO PISMENECH v listbox 
                listBox1.Items.Add(c);
            }

            streamReader.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Přečtené řádky budeme zobrazovat v listbox

            listBox1.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Na rozdíl od řetězce nemůžeme číst znak na konci souboru
            //Metoda Peek - vrací kód znaku, který je na řadě pro další čtení - zeptáme se, zda je ještě něco ke čtení,
            //pokud žádný další znak není (konec souboru) - vrátí Peek kód -1

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //(Vytvoříme prázdné textové soubory)

            //Různé způsoby zápisu cesty: (Nelze jednoduše psát opačné lomítko)
            //Při programování aplikace používejte skoro vždy relativní cesty!!!

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Zobrazí vybraný soubor
            //Soubor vybereme pomocí komponenty OpenFileDialog nebo SaveFileDialog
            //Tyto dialogy nic neotevírají ani neukládají, jen nám umožní vybrat soubor, ostatní musíme naprogramovat sami



            //Vyzkoušet jiný způsob obsloužení dialogu!!!!

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //V textovém souboru vybraném pomocí OpenFileDialogu zapíšeme
            //na konec každého řádku *

            //Textový soubor opravíme tak, že jej celý čteme, opravemé řádky nebo znaky zapisujeme
            //do pomocného textového souboru.
            //Oba streamy zavřeme, původní soubor smažeme 
            //a pomocný soubor přejmenujeme na jméno původního souboru (včetně umístění)
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }
    }
}
