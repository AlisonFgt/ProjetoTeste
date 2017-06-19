using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAlison.Entity
{
    public class Criptografia
    {
        private HashAlgorithm algoritmo;

        public Criptografia(HashAlgorithm hash)
        {
            algoritmo = hash;
        }

        public string CriptografarSenha(string senha)
        {
            var encodedValue = Encoding.UTF8.GetBytes(senha);
            var encryptedPassword = algoritmo.ComputeHash(encodedValue);

            var sb = new StringBuilder();
            foreach (var charr in encryptedPassword)
                sb.Append(charr.ToString("X2"));

            return sb.ToString();
        }

        public bool VerificaSenha(string senhaDigitada, string senhaCadastrada)
        {
            if (string.IsNullOrEmpty(senhaCadastrada))
                throw new NullReferenceException("Senha Cadastrada Invalida");

            var encryptedPassword = algoritmo.ComputeHash(Encoding.UTF8.GetBytes(senhaDigitada));

            var sb = new StringBuilder();
            foreach (var charr in encryptedPassword)
                sb.Append(charr.ToString("X2"));

            return sb.ToString().Equals(senhaCadastrada);
        }
    }
}
