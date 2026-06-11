using System.Windows;

namespace roc_projekt_2prg
{
    public partial class MainWindow : Window
    {
        private bool maKlic = false;
        private bool maLoucNezapalena = false;
        private bool maLoucZapalena = false;
        private bool maVetev = false;

        private bool maRunaME = false;
        private bool maRunaLL = false;
        private bool maRunaON = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnTruhla_Click(object sender, RoutedEventArgs e)
        {
            if (maLoucNezapalena || maLoucZapalena)
            {
                TxtTaborVypis.Text = "Truhla je již prázdná. Louč máš u sebe.";
            }
            else if (maKlic == false)
            {
                TxtTaborVypis.Text = "Truhla je pevně uzamčená starobylým zámkem. Potřebuješ najít klíč.";
            }
            else
            {
                maLoucNezapalena = true;
                TxtTaborVypis.Text = "Cvak! Otočil jsi klíčem ze stromu a truhla se otevřela! Na dně leží stará dřevěná louč. Je ale studená, budeš ji muset něčím zapálit.";
            }
        }

        private void BtnOhen_Click(object sender, RoutedEventArgs e)
        {
            if (maLoucZapalena)
            {
                TxtTaborVypis.Text = "Tvá louč už jasně hoří. Nemusíš ji zapalovat znovu.";
            }
            else if (maLoucNezapalena)
            {
                maLoucZapalena = true;
                maLoucNezapalena = false;
                TxtTaborVypis.Text = "Vložil jsi louč do plamenů. Smola okamžitě chytla a louč teď jasně září! Teď už se v podzemí neztratíš.";
            }
            else
            {
                TxtTaborVypis.Text = "Sálá z něj příjemné teplo, ale momentálně nemáš nic, co bys do ohně přiložil nebo zapálil.";
            }
        }

        private void BtnStrom_Click(object sender, RoutedEventArgs e)
        {
            if (maKlic || maLoucNezapalena || maLoucZapalena)
            {
                TxtLesVypis.Text = "Dutinu stromu už jsi prohledal. Nic dalšího tam není.";
            }
            else
            {
                maKlic = true;
                TxtLesVypis.Text = "Prohledal jsi hlubokou dutinu starého stromu. Mezi kořeny a mechem jsi našel zrezivělý železný klíč! Kam asi pasuje?";
            }
        }

        private void BtnKer_Click(object sender, RoutedEventArgs e)
        {
            if (maRunaME)
            {
                TxtLesVypis.Text = "V keři už zbývá jen trní a listí.";
            }
            else
            {
                maRunaME = true;
                TxtLesVypis.Text = "Rozhrnul jsi husté větve trnitého keře a na zemi jsi objevil kamenný úlomek s vyrytou elfskou runou 'ME'!";
            }
        }

        private void BtnJeskyneTma_Click(object sender, RoutedEventArgs e)
        {
            if (maRunaON)
            {
                TxtJeskyneVypis.Text = "Tento kout jeskyně je už prázdný.";
            }
            else
            {
                maRunaON = true;
                TxtJeskyneVypis.Text = "Se zapálenou loučí v ruce jsi posvítil do temného výklenku ve skalní stěně. Našel jsi tam schovaný třetí úlomek runy s nápisem 'ON'!";
            }
        }

        private void BtnVetev_Click(object sender, RoutedEventArgs e)
        {
            if (maVetev || maRunaLL)
            {
                TxtRekaVypis.Text = "Na zemi už leží jen drobné oblázky.";
            }
            else
            {
                maVetev = true;
                TxtRekaVypis.Text = "Zvedl jsi ze země dlouhou, pevnou naplavenou větev. Mohla by se hodit na vytažení věcí z vody.";
            }
        }

        private void BtnRekaTrpyt_Click(object sender, RoutedEventArgs e)
        {
            if (maRunaLL)
            {
                TxtRekaVypis.Text = "Hladina jezera se klidně vlní.";
            }
            else if (maVetev == false)
            {
                TxtRekaVypis.Text = "Vidíš, že na dně kousek od břehu leží zářící předmět. Voda je moc hluboká a dravá, rukou tam nedosáhneš. Potřebuješ nějaký nástroj.";
            }
            else
            {
                maRunaLL = true;
                TxtRekaVypis.Text = "Použil jsi dlouhou větev a opatrně jsi z vody přitáhl zářící předmět. Je to druhý kamenný úlomek s vyrytou runou 'LL'!";
            }
        }

        private void BtnMoriaDvere_Click(object sender, RoutedEventArgs e)
        {
            if (maRunaME && maRunaLL && maRunaON)
            {
                TxtMoriaVypis.Text = "Složil jsi všechny tři úlomky k sobě a přečetl celé heslo: 'ME - LL - ON'. Brána se s obrovským duněním otevírá! Úspěšně jsi dokončil hru!";
            }
            else
            {
                TxtMoriaVypis.Text = "Brána neodpovídá. Zdá se, že runy na dveřích jsou rozbité a chybí ti jejich části, abys dokázal přečíst nebo složit celé heslo.";
            }
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            ScenaUvod.Visibility = Visibility.Collapsed;
            ScenaTabor.Visibility = Visibility.Visible;
        }

        private void BtnEnd_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void NavTaborDoLesa_Click(object sender, RoutedEventArgs e)
        {
            ScenaTabor.Visibility = Visibility.Collapsed;
            ScenaLes.Visibility = Visibility.Visible;
            TxtLesVypis.Text = "Vstoupil jsi do tichého lesa.";
        }

        private void NavTaborDoJeskyne_Click(object sender, RoutedEventArgs e)
        {
            if (maLoucZapalena == false)
            {
                TxtTaborVypis.Text = "Do jeskyně nemůžeš vstoupit! Je tam naprostá černočerná tma a bez zapálené louče by ses zřítil do propasti.";
            }
            else
            {
                ScenaTabor.Visibility = Visibility.Collapsed;
                ScenaJeskyne.Visibility = Visibility.Visible;
                TxtJeskyneVypis.Text = "Se zapálenou loučí vstupuješ bezpečně do jeskyně. Světlo odhání temnotu.";
            }
        }

        private void NavTaborDoMorie_Click(object sender, RoutedEventArgs e)
        {
            ScenaTabor.Visibility = Visibility.Collapsed;
            ScenaMoria.Visibility = Visibility.Visible;
        }

        private void NavLesDoTabora_Click(object sender, RoutedEventArgs e)
        {
            ScenaLes.Visibility = Visibility.Collapsed;
            ScenaTabor.Visibility = Visibility.Visible;
        }

        private void NavLesDoReky_Click(object sender, RoutedEventArgs e)
        {
            ScenaLes.Visibility = Visibility.Collapsed;
            ScenaReka.Visibility = Visibility.Visible;
        }

        private void NavJeskyneDoTabora_Click(object sender, RoutedEventArgs e)
        {
            ScenaJeskyne.Visibility = Visibility.Collapsed;
            ScenaTabor.Visibility = Visibility.Visible;
        }

        private void NavRekaDoLesa_Click(object sender, RoutedEventArgs e)
        {
            ScenaReka.Visibility = Visibility.Collapsed;
            ScenaLes.Visibility = Visibility.Visible;
        }

        private void NavMoriaDoTabora_Click(object sender, RoutedEventArgs e)
        {
            ScenaMoria.Visibility = Visibility.Collapsed;
            ScenaTabor.Visibility = Visibility.Visible;
        }
    }
}