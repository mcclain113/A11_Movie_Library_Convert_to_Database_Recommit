using A11_Movie_Library_Convert_to_Database.Dao;

namespace A11_Movie_Library_Convert_to_Database.Services;

public class MainServices : IMainService
{
    private IRepository _repository;
    private IMenuGenerator _menuGenerator;
    public MainServices(IMenuGenerator menuGenerator, IRepository repository) 
    {
        _menuGenerator = menuGenerator;
        _repository = repository;
        
    }

    
    public void Invoke()
    {
        _menuGenerator.Menu(_repository); 
    }
}