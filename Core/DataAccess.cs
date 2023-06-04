using Core.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Security.Cryptography;
using System.Linq;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace Core
{
    public class DataAccess
    {
        public static User CurrentUser { get; internal set; }

        public static List<User> GetUsers() => PassLockEntities.GetContext().Users.ToList();
        public static List<Role> GetRoles() => PassLockEntities.GetContext().Roles.ToList();
        public static List<Login> GetLogins() => PassLockEntities.GetContext().Logins.ToList();
        public static List<Login> GetUserLogins(int id) => GetLogins().Where(x => x.user_id == id).ToList();
        public static List<Note> GetNotes() => PassLockEntities.GetContext().Notes.Where(x => x.user_id == CurrentUser.id).ToList();
        public static List<Document> GetDocuments() => PassLockEntities.GetContext().Documents.ToList();

        public static Role GetRole(string name) => GetRoles().FirstOrDefault(x => x.name == name);

        public static User GetUser(string login, string password)
        {
            CurrentUser = GetUsers().FirstOrDefault(x => x.login == login && x.password == password);
            return CurrentUser;
        }

        public static bool CheckLogin(User user) => PassLockEntities.GetContext().Users.Where(x => x.login == user.login).Count() == 0;

        public static void SaveUser(User user)
        {
            if (user.id == 0)
                PassLockEntities.GetContext().Users.Add(user);

            PassLockEntities.GetContext().SaveChanges();
        }

        public static bool CheckEmail(User user)
        {
            try
            {
                MailAddress m = new MailAddress(user.login);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        
        }

        public static void RemoveUser(User user)
        {
            if(user.id != 0)
            {
                PassLockEntities.GetContext().Users.Remove(user);
            }
            PassLockEntities.GetContext().SaveChanges();
        }

        public static void SaveLogin(Login login)
        {
            if(login.id == 0)
            {
                login.user_id = CurrentUser.id;
                PassLockEntities.GetContext().Logins.Add(login);
            } 

            PassLockEntities.GetContext().SaveChanges();
        }

        public static void RemoveLogin(Login login)
        {
            if (login.id != 0)
                PassLockEntities.GetContext().Logins.Remove(login);
            PassLockEntities.GetContext().SaveChanges();
        }

        public static int SaveNote(Note note)
        {
            if (note.id == 0)
            {
                note.user_id = CurrentUser.id;
                if(note.item_name != null)
                {
                    note.item_name = "Новая заметка без названия";
                }
                PassLockEntities.GetContext().Notes.Add(note);
            }
            PassLockEntities.GetContext().SaveChanges();
            return note.id;
        }

        public static void RemoveNote(Note note)
        {
            if (note.id != 0)
                PassLockEntities.GetContext().Notes.Remove(note);
            PassLockEntities.GetContext().SaveChanges();
        }

        public static int SaveDocument(Document document)
        {
            if (document.id == 0)
                PassLockEntities.GetContext().Documents.Add(document);
            PassLockEntities.GetContext().SaveChanges();
            return document.id;
        }

        public static void RemoveDocuments(Document document)
        {
            if (document.id != 0)
                PassLockEntities.GetContext().Documents.Remove(document);
            PassLockEntities.GetContext().SaveChanges();
        }

        public static void SaveNoteFiles(NoteFile noteFile)
        {
            if (noteFile.id == 0)
                PassLockEntities.GetContext().NoteFiles.Add(noteFile);
            PassLockEntities.GetContext().SaveChanges();
        }

        public static void RemoveNoteFiles(Document document)
        {
            if (document.id != 0)
                PassLockEntities.GetContext().NoteFiles.RemoveRange(document.NoteFiles);
            PassLockEntities.GetContext().SaveChanges();
        }

        public static string GetRandomPassword(int length = 16)
        {
            byte[] rgb = new byte[length];
            RNGCryptoServiceProvider rngCrypt = new RNGCryptoServiceProvider();
            rngCrypt.GetBytes(rgb);
            return Convert.ToBase64String(rgb);
        }

    }
}
