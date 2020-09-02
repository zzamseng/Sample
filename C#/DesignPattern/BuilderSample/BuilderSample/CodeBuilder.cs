using System;
using System.Collections.Generic;

namespace BuilderSample.CodeBuilderTest
{

    public class ClassGenerator
    {
        public string ClassName { get; set; }
        public Dictionary<string, string> Fields = new Dictionary<string, string>();

        public override string ToString()
        {
            string str = "";

            str = $"public class {ClassName}" + Environment.NewLine;
            str += "{" + Environment.NewLine;

            foreach (var key in Fields.Keys)
            {
                string indent = new string(' ', 2);

                str += indent;
                str += $"public {key} {Fields[key]};" + Environment.NewLine;
            }

            str += "}";

            return str;

        }
    }

    public class CodeBuilder
    {
        private ClassGenerator _classGenerator = new ClassGenerator();

        public static implicit operator ClassGenerator(CodeBuilder builder) => builder._classGenerator;
        
        public CodeBuilder(string name)
        {
            _classGenerator.ClassName = name;
        }

        public CodeBuilder AddFiled(string type, string val)
        {
            _classGenerator.Fields.Add(type, val);

            return this;
        }

        public override string ToString()
        {
            return _classGenerator.ToString();
        }

    }
}
