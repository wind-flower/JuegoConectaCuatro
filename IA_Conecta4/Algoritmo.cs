using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_Conecta4
{
    public abstract class Algoritmo
    {
        public int minimax(int profundidad, bool maximizandoJugador)
        {
            if (profundidad == 0 || TerminarJuego())
            {
                CalcularValor();
                return Valor;
            }
            if (maximizandoJugador)
            {
                GenerarFicha(maximizandoJugador);
                Valor = int.MinValue;
                foreach (var h in Fichas)
                {
                    Valor = Math.Max(Valor, h.minimax(profundidad - 1, false));
                }
                return Valor;
            }
            else
            {
                GenerarFicha(maximizandoJugador);
                Valor = int.MaxValue;
                foreach (var h in Fichas)
                {
                    Valor = Math.Min(Valor, h.minimax(profundidad - 1, true));
                }
                return Valor;
            }
        }

        public int Valor { get; protected set; }
        public abstract void CalcularValor();
        public List<Algoritmo> Fichas { get; set; }
        public abstract void GenerarFicha(bool EsTurnoPC);
        public abstract bool TerminarJuego();
    }
}
