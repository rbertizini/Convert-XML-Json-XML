// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.Text;
using System.Xml;

Console.WriteLine("Conversão XML-Json-XML");
Console.WriteLine("");

ConverterXML();

void ConverterXML()
{
    //Diretório
    string strDir = AppDomain.CurrentDomain.BaseDirectory;
    if (!File.Exists(Path.Combine(strDir, "XML-Original.xml")))
        Console.WriteLine("Arquivo não localizado - processo cancelado");

    //Ler arquivo XML para string
    string xmlOrig = File.ReadAllText(Path.Combine(strDir, "XML-Original.xml"), Encoding.UTF8);

    //Converter string XML para Json
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xmlOrig);
    string strJson = JsonConvert.SerializeXmlNode(doc);

    SalvarArquivo(Path.Combine(strDir, "Json-gerado.json"), strJson);    

    //Convertendo string Json para XML
    XmlDocument docXml = JsonConvert.DeserializeXmlNode(strJson);

    SalvarArquivo(Path.Combine(strDir, "Xml-gerado.xml"), docXml.InnerXml);
    
}

void SalvarArquivo(string arqNome, string strCont)
{
    //Exclusão de arquivo existente
    File.Delete(arqNome);
    
    //Salvar arquivo
    File.WriteAllText(arqNome, strCont, Encoding.UTF8);
}