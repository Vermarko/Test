using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayWriteTests
{
    internal class loginHelp
    {
        public static void LoginHelp(ExtentReports test1)
        {
         ExtentTest loginNode = test1.CreateTest("Fase 1: Login utente");
         loginNode.Info("Inizio del processo di login. Verifica delle credenziali dell'utente.");
            /// Credenziali fittizie cablate(hardcoded)
        const string UsernameCorretto = "admin";
        const string PasswordCorretta = "Secret123!";

        Console.WriteLine("=== SISTEMA DI LOGIN ===");
        
        Console.Write("Inserisci Username: ");
        //string usernameInserito = Console.ReadLine();
        string usernameInserito = "admin";
            Console.Write("Inserisci Password: ");
        //string passwordInserita = Console.ReadLine();
        string passwordInserita = "Secret123";
        // Verifica delle credenziali inserite
        if (usernameInserito == UsernameCorretto && passwordInserita == PasswordCorretta)
            {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n[OK] Accesso consentito! Benvenuto nel sistema.");
            loginNode.Pass("Login eseguito con successo. Sessione avviata.");
            }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n[ERRORE] Username o Password non validi.");
            loginNode.Fail("Login fallito. Credenziali non valide.");
        }

Console.ResetColor();
//Console.WriteLine("\nPremere un tasto per uscire...");
//Console.ReadKey();
    }
    }
}
