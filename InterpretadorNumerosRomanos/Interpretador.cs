using System.Collections.Generic;
using System.Linq;

namespace InterpretadorNumerosRomanos
{
    public class Interpretador
    {
        private IDictionary<char, int> _numerosRomanos = 
            new Dictionary<char, int>() { { 'I' , 1 }, { 'V', 5 }, { 'X', 10 } , { 'L', 50 }, { 'C', 100 } , { 'D', 500 }, { 'M', 1000 }, { '\0', 0 } };        

        public int Converter(string entrada)
        {
            //Resposta Adriano
            //var letras = entrada.ToCharArray();
            //var soma = 0;
            //var anterior = 0;

            //foreach (var letra in letras)
            //{
            //    var atual = _numerosRomanos[letra];
            //    soma += anterior < atual ? atual - (anterior * 2) : atual;
            //    anterior = atual;

            //}
            //return soma;

            //Resposta Tiago
            //var letras = entrada.ToCharArray();
            //resposta 1
            //var resultado = new List<int>();
            //var contador = 0;
            //do
            //{
            //    var atual = _numerosRomanos[letras[contador]];
            //    if (contador > 0)
            //    {
            //        var anterior = _numerosRomanos[letras[contador - 1]];                    
            //        if (atual > anterior)
            //        {
            //            resultado.RemoveAt(resultado.LastIndexOf(anterior));
            //            resultado.Add(anterior * -1);
            //        }
            //    }
            //    resultado.Add(atual);
            //    contador++;
            //} while (contador < letras.Length);                      
            //return resultado.Sum();

            //resposta 2
            //var letras = entrada.ToCharArray();
            //var resultado = new List<int>();
            //letras.ToList().ForEach(letra =>
            //{
            //    var atual = _numerosRomanos[letra];                
            //    var anterior = _numerosRomanos[letras.TakeWhile(x => !x.Equals(letra)).LastOrDefault()];
            //    //Se o atual é maior que o anterior então o anterior deveria ficar negativo                
            //    if (anterior !=  0 && atual > anterior)
            //    {
            //        resultado.RemoveAt(resultado.LastIndexOf(anterior));
            //        resultado.Add(anterior * -1);
            //    }
            //    resultado.Add(atual);                                    
            //});
            //return resultado.Sum();

            //resposta 3
            var letras = entrada.ToCharArray();            
            var resultado = letras.Select(letra =>
            {
                var atual = _numerosRomanos[letra];
                var proximo = _numerosRomanos[letras.SkipWhile(x => !x.Equals(letra)).Skip(1).FirstOrDefault()];                
                if (atual < proximo)                
                    return atual * -1;

                return atual;
            });
            return resultado.Sum();
        }
    }
}
