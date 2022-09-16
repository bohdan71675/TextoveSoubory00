using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

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
            StreamWriter streamWriter = new StreamWriter("Text.txt", true);
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
            //    string text = streamReader.ReadLine();       //// ZOBRAZI CELY radek (text) v listbox 
            //    listBox1.Items.Add(text);
            //}
            while (!streamReader.EndOfStream)
            {
                char c = (char)streamReader.Read();         // ZOBRAZI text PO PISMENECH v listbox  
                listBox1.Items.Add(c);                      // Read cte jen jedno pismeno a zastavi se
            }

            streamReader.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Přečtené řádky budeme zobrazovat v listbox

            listBox1.Items.Clear();
            StreamReader streamReader = new StreamReader("Text.txt");

            while (!streamReader.EndOfStream)
            {
                string text = streamReader.ReadLine();       //// ZOBRAZI CELY radek (text) v listbox 
                listBox1.Items.Add(text);                    //ReadLine precte radek a zastavi se
            }
            streamReader.Close();
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

            StreamWriter streamWriter = new StreamWriter("text1.txt");    // V AKTUALNI SLOZCE

            streamWriter.Close();

            streamWriter = new StreamWriter("..\\..\\text2.txt");
            streamWriter.Close();

            streamWriter = new StreamWriter("../../text3.txt");  
            streamWriter.Close();

            streamWriter = new StreamWriter(@"..\..\text4.txt");     // @  -  lomitka jsou jen obicejne lomitka
            streamWriter.Close();

            streamWriter = new StreamWriter(@"..\..\SOUBORY\text5.txt");    //zapise do konkretni slozky
            streamWriter.Close();


            //Různé způsoby zápisu cesty: (Nelze jednoduše psát opačné lomítko)
            //Při programování aplikace používejte skoro vždy relativní cesty!!!

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //Zobrazí vybraný soubor
            //Soubor vybereme pomocí komponenty OpenFileDialog nebo SaveFileDialog
            //Tyto dialogy nic neotevírají ani neukládají, jen nám umožní vybrat soubor, ostatní musíme naprogramovat sami

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                listBox3.Items.Clear();
                StreamReader streamReader = new StreamReader(openFileDialog1.FileName);

                while (!streamReader.EndOfStream)
                {
                    string text = streamReader.ReadLine();
                    listBox3.Items.Add(text);
                }
                streamReader.Close();
            }
            else
            {
                MessageBox.Show("Nebyl vybran zadny soubor");
            }

            //Vyzkoušet jiný způsob obsloužení dialogu!!!!

            //////////////////////////////////////////////////SaveFileDialog funguje skoro stejne xD

        }

        private void button9_Click(object sender, EventArgs e)
        {
            //V textovém souboru vybraném pomocí OpenFileDialogu zapíšeme
            //na konec každého řádku *

            //Textový soubor opravíme tak, že jej celý čteme, opravemé řádky nebo znaky zapisujeme
            //do pomocného textového souboru.
            //Oba streamy zavřeme, původní soubor smažeme 
            //a pomocný soubor přejmenujeme na jméno původního souboru (včetně umístění)

            listBox4.Items.Clear();
            listBox5.Items.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog1.FileName);
                StreamWriter sw = new StreamWriter("pomocny.txt");

                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    listBox4.Items.Add(line);
                    line += "*";
                    sw.WriteLine(line);
                }

                streamReader.Close();
                sw.Close();

                File.Delete(openFileDialog1.FileName);
                File.Move("pomocny.txt", openFileDialog1.FileName);

                //Zobrazi opraveny soubor
                streamReader = new StreamReader(openFileDialog1.FileName);
                while (!streamReader.EndOfStream)
                {
                    string s = streamReader.ReadLine();
                    listBox5.Items.Add(s);
                }
                streamReader.Close();
            }
            else
            {
                MessageBox.Show("Nebyl vybrán žádný soubor");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Pokud neurcime kodovani, bude v Unicode
            StreamWriter sw = new StreamWriter("KodovaniNeuceno.txt");
            sw.WriteLine("Vizaž");
            sw.WriteLine("prešivany");
            sw.Close();

            //Trida Encoding
            //***************

            //Metoda GetEncoding - vrati kodovani zadane kodove stranky (kodovou stranku zadame kodem)

            StreamWriter sw1250 = new StreamWriter("W1250.txt", false, Encoding.GetEncoding("windows-1250"));
            sw1250.WriteLine("Vizaž");
            sw1250.WriteLine("prešivany");
            sw1250.Close();


            StreamWriter swDef = new StreamWriter("Default.txt", false, Encoding.Default);
            swDef.WriteLine("Vizaž");
            swDef.WriteLine("prešivany");
            swDef.Close();


            //Zapis obsahu ze vsech tri souboru do TextBox
            //*****************************************************

            StreamReader sr = new StreamReader("KodovaniNeurceno.txt");
            textBox1.Text = "KODOVANI JSME NEURCILI" + "\r\n";
            textBox1.Text += sr.ReadToEnd();
            sr.Close();

            sr = new StreamReader("W1250.txt", Encoding.GetEncoding(1250));
            textBox1.Text += "\r\nSOUBOR Windows1250\r\n";
            textBox1.Text += sr.ReadToEnd();
            sr.Close();

            sr = new StreamReader("Default.txt", Encoding.Default);
            textBox1.Text += "\r\nSOUBOR DEFAULTNI KODOVANI\r\n";
            textBox1.Text += sr.ReadToEnd();
            sr.Close();

        }
    }
}
