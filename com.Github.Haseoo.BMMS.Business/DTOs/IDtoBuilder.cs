namespace com.Github.Haseoo.BMMS.Business.DTOs
{
    public interface IDtoBuilder<out T>
    {
        T Build();
    }
}
