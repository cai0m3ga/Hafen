namespace Hafen.Domain.Entities.Common;

public interface IEntity
{

    public bool Valid();

    public List<string> ValidationErrors();

}