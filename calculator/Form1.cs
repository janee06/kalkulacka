using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        // proměnné, prvniCislo uloží si první zadané číslo, operace uloží si jakou operaci uživatel vybral, novaZprava značí, že další kliknutí na číslo má vymazat displej
        string prvniCislo = "";
        string operace = "";
        bool novaZprava = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // je to metoda, která se spustí když uživatel klikne na nějaké číslo
        // sender je objekt, na který uživatel klikl
        // kód říká aby přetvořil sender na tlačítko, abychom s ním mohli pracovat jako s tlačítkem
        // podmínka if znamená že když uživatel klik na nějakou operaci(např. +), tak se display vymaže
        // potom se přidá text z tlačitka k tomu co už je na displeji
        private void Cislo_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (novaZprava)
            {
                txtDisplej.Text = "";
                novaZprava = false;
            }
            txtDisplej.Text += btn.Text;
        }


        // tahle metoda uloží první číslo, které uživatel zadal, potom uloží operaci, kterou uživatel zvolil 
        // tahle hodnota se pak použije v metodě btnEq_Click, kde se provede samotný výpoče
        // novaZprava = true; znamená že příští psaní čísla začne s prázdným displejem
        private void Operace_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            prvniCislo = txtDisplej.Text;
            operace = btn.Text;
            novaZprava = true;
        }


        // metoda pro sčítaní, odčítání, násobení a dělení pomocí switch
        // převádí zadané čísla na double
        // je to ošetřené tak aby se nedalo dělit nulou
        // na konci to zobrazí výsledek ( txtDisplej.Text = vysledek.ToString();)
        // po zobrazení výsledku může uživatel zadávat nové čísla
        private void btnEq_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(prvniCislo);
            double b = Convert.ToDouble(txtDisplej.Text);
            double vysledek = 0;

            switch (operace)
            {
                case "+": vysledek = a + b; break;
                case "-": vysledek = a - b; break;
                case "*": vysledek = a * b; break;
                case "/":
                    if (b == 0)
                    {
                        txtDisplej.Text = "Chyba";
                        return;
                    }
                    vysledek = a / b;
                    break;
            }

            txtDisplej.Text = vysledek.ToString();
            novaZprava = true;
        }


        // tato metoda vyčistí displej a všechny uložené hodnoty
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplej.Text = "";
            prvniCislo = "";
            operace = "";
        }
    }
}
