namespace DumpLogger;
using System.Reflection;

// Crud Logger 
public class DumpLogger
{
    private readonly string _path = Directory.GetCurrentDirectory() + "\\Dump\\Logger\\";
    private string _ext = "txt";
    private readonly string _fileName = "log.";

    private string? _fullFilePath;
    // Constructor
    public DumpLogger(string loggerFolder) => _path += loggerFolder;
    // Methods
    public void Create(string content)
    {
        MethodBase? GetMethod = MethodBase.GetCurrentMethod();
        if (GetMethod!.Name is not null)
        {
            DumpStreamWriter(content: content, method: GetMethod!.Name);
        }
    }
    public void Create(string content, string fileExtension)
    {
        MethodBase? GetMethod = MethodBase.GetCurrentMethod();
        if (GetMethod!.Name is not null)
        {
            _ext = fileExtension;
            DumpStreamWriter(content: content, method: GetMethod!.Name);
        }
    }
    public void Read(string content)
    {
        MethodBase? GetMethod = MethodBase.GetCurrentMethod();
        if (GetMethod!.Name is not null)
        {
            DumpStreamWriter(content: content, method: GetMethod!.Name);
        }
    }
    public void Read(string content, string fileExtension)
    {
        MethodBase? GetMethod = MethodBase.GetCurrentMethod();
        if (GetMethod!.Name is not null)
        {
            _ext = fileExtension;
            DumpStreamWriter(content: content, method: GetMethod!.Name);
        }
    }
    public void Update(string content)
    {
        MethodBase? GetMethod = MethodBase.GetCurrentMethod();
        if (GetMethod!.Name is not null)
        {
            DumpStreamWriter(content: content, method: GetMethod!.Name);
        }
    }
    public void Update(string content, string fileExtension)
    {
        MethodBase? GetMethod = MethodBase.GetCurrentMethod();
        if (GetMethod!.Name is not null)
        {
            _ext = fileExtension;
            DumpStreamWriter(content: content, method: GetMethod!.Name);
        }
    }
    public void Delete(string content)
    {
        MethodBase? GetMethod = MethodBase.GetCurrentMethod();
        if (GetMethod!.Name is not null)
        {
            DumpStreamWriter(content: content, method: GetMethod!.Name);
        }
    }
    public void Delete(string content, string fileExtension)
    {
        MethodBase? GetMethod = MethodBase.GetCurrentMethod();
        if (GetMethod!.Name is not null)
        {
            _ext = fileExtension;
            DumpStreamWriter(content: content, method: GetMethod!.Name);
        }
    }

    private void DumpError(string content)
    {
        MethodBase? GetMethod = MethodBase.GetCurrentMethod();
        if (GetMethod!.Name is not null)
        {
            DumpStreamWriter(content: "Method Status Not Found", method: GetMethod!.Name);
        }
    }

    private void DumpStreamWriter(string content, string method)
    {
        string filePath = _path + $"\\{method}";
        if (Directory.Exists(filePath))
        {
            _fullFilePath = filePath + "\\" + _fileName + _ext;
            string contentOld = DumpStreamReader(_fullFilePath);
            StreamWriter File = new(_fullFilePath);
            File.WriteLine(contentOld + content);
            File.Close();
        }
        else
        {
            Directory.CreateDirectory(filePath);
            switch (method)
            {
                case "Create":
                    Create(content);
                    break;
                case "Read":
                    Read(content);
                    break;
                case "Update":
                    Update(content);
                    break;
                case "Delete":
                    Delete(content);
                    break;
                default:
                    DumpError(content);
                    break;
            }
        }
    }

    private static string DumpStreamReader(string file)
    {
        StreamReader reader = new(file);
        string dataEntry = reader.ReadToEnd();
        reader.Close();
        if (dataEntry.Length <= 0)
        {
            dataEntry = "";
            return dataEntry;
        }
        return dataEntry;
    }
}