namespace TP3_VisionSante;

internal class MenuItem
{
    public char Cle {  get; set; }  
    public string Nom {  get; set; }   
    public Action Execution {  get; set; }  

    public MenuItem(char c, string n, Action exe)
    {
        Cle = c;
        Nom = n;
        Execution = exe;
    }   
}
