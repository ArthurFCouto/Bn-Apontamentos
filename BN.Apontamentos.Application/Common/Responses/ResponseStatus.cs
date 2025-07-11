namespace BN.Apontamentos.Application.Common.Responses
{
    public enum ResponseStatus
    {
        Success = 200,
        NoContent = 204,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        InternalServerError = 500
    }
}
