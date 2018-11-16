using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    class ProgrammingLanguage
    {
        private string nameLang;
        private float versionLang;
       
        private List<String> operationInLang = new List<String>();
        private string newOpt;
        private string delOpt;

        public string NewOpt
        {
            set => newOpt = value;
        }
        public string DelOpt
        {
            set => delOpt = value;
        }
        public string NameLang
        {
            get => nameLang;
            set => nameLang = value;
        }

        public float VersionLang
        {
            get => versionLang;
            set => versionLang = value;
        }

        public void GetOperation()
        {
            foreach (string arr in operationInLang)
            {
                Console.WriteLine($"{arr}");
            }
        }

        public void AddOperation(Object sender, EventArgs e)
        {
            operationInLang.Add(newOpt);
            Console.WriteLine($"Мы добавили в нашу программу: {NameLang}-{newOpt}");
            NewVersion();
        }

        public void DeleteOptions(Object sender, EventArgs e)
        {
            operationInLang.Remove(delOpt);
            Console.WriteLine($"Мы исключили из нашей программы: {NameLang}-{delOpt}");
            NewVersion();
        }

        public void NewVersion(Object sender, EventArgs e)
        {
            VersionLang = VersionLang + 1.0f;
            versionLang = (float)(int)(VersionLang);
            Console.WriteLine($"Мы используем новую версию нашей программы: {NameLang}-{VersionLang}");
        }

        public void NewVersion()
        {
            VersionLang = VersionLang + 0.1f;
            Console.WriteLine($"Мы обновили версию нашей программы: {NameLang}-{VersionLang}");

        }

        public ProgrammingLanguage(string nameLang)
        {
            this.nameLang = nameLang;
        }
        public ProgrammingLanguage(string nameLang, float versionLang) : this(nameLang)
        {
            this.versionLang = versionLang;
        }
        public ProgrammingLanguage(string nameLang, float versionLang, params string[] arrOptions): this(nameLang,versionLang)
        {
            foreach(string arr in arrOptions)
            {
                operationInLang.Add(arr);
            }
        }

        public override string ToString()
        {
            return $"{nameLang} v-{versionLang}";
        }
    }
}
