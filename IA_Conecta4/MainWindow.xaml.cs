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

namespace IA_Conecta4
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NodoJuego nodo_Juego = new NodoJuego();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 42; i++)
            {
                Border b = GenerarTablero_Fichas();
                b.Background = Brushes.Black;

                grdTablero.Children.Add(b);
            }
            grdTablero.IsEnabled = false;
           
        }

        private Border GenerarTablero_Fichas()
        {
            Border b = new Border();
            b.CornerRadius = new CornerRadius(80);
            b.Width = 90;
            b.Height = 90;
            b.VerticalAlignment = VerticalAlignment.Center;
            b.HorizontalAlignment = HorizontalAlignment.Center;
            return b;
        }

        private bool IniciarJuego4()
        {
            if (grdTablero.Children.Count == 0)
                return false;
            else
                return true;
        }

        //private void btnIniciar_Click(object sender, RoutedEventArgs e)
        //{

        //    //for (int i = 0; i < 42; i++)
        //    //{
        //    //    Border b = GenerarTablero_Fichas();
        //    //    b.Background = Brushes.Black;

        //    //    grdTablero.Children.Add(b);
        //    //}
        //    grdTablero.IsEnabled = true;
          
        //}

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Fila_Cero(object sender, MouseButtonEventArgs e)
        {
            if (IniciarJuego4())
            {
                for (int i = 5; i >= 0; i--)
                {
                    if (nodo_Juego.Estado[i * 7] == ' ')
                    {
                        nodo_Juego.Estado[i * 7] = 'J';

                        int result = nodo_Juego.minimax(3, true);

                        if (nodo_Juego.Fichas == null)
                        {
                            MessageBox.Show("Juego terminado");
                            this.Close();
                            return;
                        }

                        Border b = GenerarTablero_Fichas();
                        b.Background = Brushes.Red;
                        grdTablero.Children.RemoveAt(i * 7);
                        grdTablero.Children.Insert(i * 7, b);

                        NodoJuego nodo = (nodo_Juego.Fichas.FirstOrDefault(x => x.Valor == result)) as NodoJuego;
                        for (int j = 0; j < 42; j++)
                        {
                            if (nodo_Juego.Estado[j] != nodo.Estado[j])
                            {
                                nodo_Juego.Estado[j] = nodo.Estado[j];
                                Border b2 = GenerarTablero_Fichas();
                                b2.Background = Brushes.Yellow;
                                grdTablero.Children.RemoveAt(j);
                                grdTablero.Children.Insert(j, b2);
                                nodo_Juego.Fichas = null;

                                return;
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show("No se ha inicializado una partida");
        }

        private void Fila_Uno(object sender, MouseButtonEventArgs e)
        {
            if (IniciarJuego4())
            {
                for (int i = 5; i >= 0; i--)
                {
                    if (nodo_Juego.Estado[i * 7 + 1] == ' ')
                    {
                        nodo_Juego.Estado[i * 7 + 1] = 'J';

                        int result = nodo_Juego.minimax(3, true);

                        if (nodo_Juego.Fichas == null)
                        {
                            MessageBox.Show("Juego terminado");
                            this.Close();
                            return;
                        }

                        Border b = GenerarTablero_Fichas();
                        b.Background = Brushes.Red;
                        grdTablero.Children.RemoveAt(i * 7 + 1);
                        grdTablero.Children.Insert(i * 7 + 1, b);

                        NodoJuego nodo = (nodo_Juego.Fichas.FirstOrDefault(x => x.Valor == result)) as NodoJuego;
                        for (int j = 0; j < 42; j++)
                        {
                            if (nodo_Juego.Estado[j] != nodo.Estado[j])
                            {
                                nodo_Juego.Estado[j] = nodo.Estado[j];
                                Border b2 = GenerarTablero_Fichas();
                                b2.Background = Brushes.Yellow;
                                grdTablero.Children.RemoveAt(j);
                                grdTablero.Children.Insert(j, b2);
                                nodo_Juego.Fichas = null;
                                return;
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show("No se ha inicializado una partida");
        }

        private void Fila_Dos(object sender, MouseButtonEventArgs e)
        {
            if (IniciarJuego4())
            {
                for (int i = 5; i >= 0; i--)
                {
                    if (nodo_Juego.Estado[i * 7 + 2] == ' ')
                    {
                        nodo_Juego.Estado[i * 7 + 2] = 'J';

                        int result = nodo_Juego.minimax(3, true);

                        if (nodo_Juego.Fichas == null)
                        {
                            MessageBox.Show("Juego terminado");
                            this.Close();
                            return;
                        }

                        Border b = GenerarTablero_Fichas();
                        b.Background = Brushes.Red;
                        grdTablero.Children.RemoveAt(i * 7 + 2);
                        grdTablero.Children.Insert(i * 7 + 2, b);

                        NodoJuego nodo = (nodo_Juego.Fichas.FirstOrDefault(x => x.Valor == result)) as NodoJuego;
                        for (int j = 0; j < 42; j++)
                        {
                            if (nodo_Juego.Estado[j] != nodo.Estado[j])
                            {
                                nodo_Juego.Estado[j] = nodo.Estado[j];
                                Border b2 = GenerarTablero_Fichas();
                                b2.Background = Brushes.Yellow;
                                grdTablero.Children.RemoveAt(j);
                                grdTablero.Children.Insert(j, b2);
                                nodo_Juego.Fichas = null;
                               
                                return;
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show("No se ha inicializado una partida");
        }

        private void Fila_Tres(object sender, MouseButtonEventArgs e)
        {
            if (IniciarJuego4())
            {
                for (int i = 5; i >= 0; i--)
                {
                    if (nodo_Juego.Estado[i * 7 + 3] == ' ')
                    {
                        nodo_Juego.Estado[i * 7 + 3] = 'J';

                        int result = nodo_Juego.minimax(3, true);

                        if (nodo_Juego.Fichas == null)
                        {
                            MessageBox.Show("Juego terminado");
                            this.Close();
                            return;
                        }

                        Border b = GenerarTablero_Fichas();
                        b.Background = Brushes.Red;
                        grdTablero.Children.RemoveAt(i * 7 + 3);
                        grdTablero.Children.Insert(i * 7 + 3, b);

                        NodoJuego nodo = (nodo_Juego.Fichas.FirstOrDefault(x => x.Valor == result)) as NodoJuego;
                        for (int j = 0; j < 42; j++)
                        {
                            if (nodo_Juego.Estado[j] != nodo.Estado[j])
                            {
                                nodo_Juego.Estado[j] = nodo.Estado[j];
                                Border b2 = GenerarTablero_Fichas();
                                b2.Background = Brushes.Yellow;
                                grdTablero.Children.RemoveAt(j);
                                grdTablero.Children.Insert(j, b2);
                                nodo_Juego.Fichas = null;
                           
                                return;
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show("No se ha inicializado una partida");
        }

        private void Fila_Cuatro(object sender, MouseButtonEventArgs e)
        {
            if (IniciarJuego4())
            {
                for (int i = 5; i >= 0; i--)
                {
                    if (nodo_Juego.Estado[i * 7 + 4] == ' ')
                    {
                        nodo_Juego.Estado[i * 7 + 4] = 'J';

                        int result = nodo_Juego.minimax(3, true);

                        if (nodo_Juego.Fichas == null)
                        {
                            MessageBox.Show("Juego terminado");
                            this.Close();
                            return;
                        }

                        Border b = GenerarTablero_Fichas();
                        b.Background = Brushes.Red;
                        grdTablero.Children.RemoveAt(i * 7 + 4);
                        grdTablero.Children.Insert(i * 7 + 4, b);

                        NodoJuego nodo = (nodo_Juego.Fichas.FirstOrDefault(x => x.Valor == result)) as NodoJuego;
                        for (int j = 0; j < 42; j++)
                        {
                            if (nodo_Juego.Estado[j] != nodo.Estado[j])
                            {
                                nodo_Juego.Estado[j] = nodo.Estado[j];
                                Border b2 = GenerarTablero_Fichas();
                                b2.Background = Brushes.Yellow;
                                grdTablero.Children.RemoveAt(j);
                                grdTablero.Children.Insert(j, b2);
                                nodo_Juego.Fichas = null;
                          
                                return;
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show("No se ha inicializado una partida");
        }

        private void Fila_Cinco(object sender, MouseButtonEventArgs e)
        {
            if (IniciarJuego4())
            {
                for (int i = 5; i >= 0; i--)
                {
                    if (nodo_Juego.Estado[i * 7 + 5] == ' ')
                    {
                        nodo_Juego.Estado[i * 7 + 5] = 'J';

                        int result = nodo_Juego.minimax(3, true);

                        if (nodo_Juego.Fichas == null)
                        {
                            MessageBox.Show("Juego terminado");
                            this.Close();
                            return;
                        }

                        Border b = GenerarTablero_Fichas();
                        b.Background = Brushes.Red;
                        grdTablero.Children.RemoveAt(i * 7 + 5);
                        grdTablero.Children.Insert(i * 7 + 5, b);

                        NodoJuego nodo = (nodo_Juego.Fichas.FirstOrDefault(x => x.Valor == result)) as NodoJuego;
                        for (int j = 0; j < 42; j++)
                        {
                            if (nodo_Juego.Estado[j] != nodo.Estado[j])
                            {
                                nodo_Juego.Estado[j] = nodo.Estado[j];
                                Border b2 = GenerarTablero_Fichas();
                                b2.Background = Brushes.Yellow;
                                grdTablero.Children.RemoveAt(j);
                                grdTablero.Children.Insert(j, b2);
                                nodo_Juego.Fichas = null;
            
                                return;
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show("No se ha inicializado una partida");
        }

        private void Fila_Seis(object sender, MouseButtonEventArgs e)
        {
            if (IniciarJuego4())
            {
                for (int i = 5; i >= 0; i--)
                {
                    if (nodo_Juego.Estado[i * 7 + 6] == ' ')
                    {
                        nodo_Juego.Estado[i * 7 + 6] = 'J';

                        int result = nodo_Juego.minimax(3, true);

                        if (nodo_Juego.Fichas == null)
                        {
                            MessageBox.Show("Juego terminado");
                            this.Close();
                            return;
                        }

                        Border b = GenerarTablero_Fichas();
                        b.Background = Brushes.Red;
                        grdTablero.Children.RemoveAt(i * 7 + 6);
                        grdTablero.Children.Insert(i * 7 + 6, b);

                        NodoJuego nodo = (nodo_Juego.Fichas.FirstOrDefault(x => x.Valor == result)) as NodoJuego;
                        for (int j = 0; j < 42; j++)
                        {
                            if (nodo_Juego.Estado[j] != nodo.Estado[j])
                            {
                                nodo_Juego.Estado[j] = nodo.Estado[j];
                                Border b2 = GenerarTablero_Fichas();
                                b2.Background = Brushes.Yellow;
                                grdTablero.Children.RemoveAt(j);
                                grdTablero.Children.Insert(j, b2);
                                nodo_Juego.Fichas = null;
           
                                return;
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show("No se ha inicializado una partida");
        }
    }
}