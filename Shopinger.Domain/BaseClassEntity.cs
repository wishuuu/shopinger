namespace Shopinger.Domain;

public class BaseClassEntity : BaseClass
{
    public int Id { get; set; }

    public void CopyProperties(BaseClassEntity entity)
    {
    }
}