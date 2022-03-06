namespace CvApp.Repositories.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entityId)
        : base($"Entity with id '{entityId}' not found")
        {
        }
    }
}
