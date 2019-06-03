//------------------------------------------------------------------------------
// <copyright file="CSSqlClassFile.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Metaphone_BR
{
    public class MetaphonePtBr : Metaphone
    {
        public MetaphonePtBr(string text) : base(text)
        {

        }

        protected internal override void Prepare()
        {
            // Essa letras duplicadas s�o apenas dor de cabe�a. Antes de come�ar, tiramos o excesso.
            // Otto, Rizzo, Millene, Riccardo (�... com dois "c", achei um desses, � mole?) 
            RemoveMultiples(" ", "b", "c", "g", "l", "t", "p", "d", "f", "j", "k", "m", "v", "n", "z");
        }

        protected internal override void Algorithm()
        {
            // Nomes antigos
            Translate("ph", "F"); // Alphonso
            Translate("th", "T"); // Martha

            Translate("lh", "1");
            // Gald�ncio ou Gaud�ncio? Descartamos como se fosse vogal
            Ignore("(l)" + NON_VOWEL);
            Translate("l", "L");

            Translate("g[eiy]", "J");
            Translate("g[ao]", "G");
            Translate("gu[ei]", "G");
            Translate("g", "G");

            /* C parecia mais simples no come�o */

            // O erro de digita��o mais comum q existe "cao" = "��o",
            // n�o faz parte do metaphone, mas...
            Translate("cao", "S");
            // "Belchior" (Belkior, n�o Belxior) parece ser exce��o
            // mas me lembro de "Melchior" em algum lugar, tamb�m.
            Translate("l(chior)\\s", "K2");
            Translate("ch", "X");
            Translate("ck", "K"); // Volta e meia tem uma "Jackeline"
            Translate("cq", "K"); // E um ou outro "Jacques" perdido
            Translate("c[eiy]", "S");
            Translate("c[aou]", "K");
            Translate("c", "K");
            Translate("�", "S");

            Translate("rr", "2");
            Translate("\\s(r)", "2"); // Raul, R�gis
            Translate("(r)\\s", "2"); // Adamastor, Maber (ou seria melhor "R"?)
            Translate("r", "R"); // Maria, Marcelo (ou seria melhor "2"?)

            Translate("(z)\\s", "S"); // Luiz, Tomaz
            Translate("z", "Z");

            Translate("(n)\\s", "M"); // Renan
            Translate("nh", "3");
            Translate("n", "N");

            Translate("ss", "S");
            Translate("\\s(s)", "S"); // sela, Sebasti�o
            Translate("(s)\\s", "S"); // mas, Marcos
            Translate("sh", "X"); // Koshi
            Translate(VOWEL + "(s)" + VOWEL, "Z"); // asa, Isabel
            Translate("sc[ei]", "S"); // asceta
            Translate("sc[aou]", "SC"); // masca
            Translate("s", "S");

            /* X � um pesadelo... por sorte n�o temos muitos nomes pr�prios com X */

            // Algumas s�labas e encontros como "ca", "ai" ou "ei" antes do X
            // parecem provocar o som de CH ao inv�s de KS
            Translate("[ckglrxaeiou][aeiou](x)", "X"); // abacaxi, Aleixo, Alexandre
            Translate("\\s(x)", "X"); // Xavier
            Translate("x\\s", "KS"); // F�lix
            Translate("xc[ei]", "S"); // exce��o, excel�ncia, excita��o
            Translate("\\se(x)" + VOWEL, "Z"); // exemplo, exerc�cio, ex�mio
            Translate("\\se(x)" + NON_VOWEL, "S"); // �xtase, exposi��o
            // mexe, mexido... U�xinton :D ... mas... e m�ximo e t�xi? :(
            Translate("x[ei]", "X");
            Translate("x[aou]", "KS"); // sexo, anexo,
            Translate("x", "KS"); // o resto

            // O resto
            Translate("q", "K");
            Translate("\\sh(" + VOWEL + ")", THE_MATCH);
            Translate("w" + VOWEL, "V");
            Ignore("h");

            // Essas consoantes s�o fortes, tem o som que tem.
            Keep("b", "t", "p", "d", "f", "j", "k", "m", "v");

            // Vogal no come�o � a pr�pria vogal
            Translate("\\s(" + VOWEL + ")", THE_MATCH);

            // O resto das vogais s�o ignoradas
            Ignore(VOWEL);
        }
    }
}
