namespace EmployeeManagement.Web.Infrastructure.Configurations
{
    public static class AwsLambdaConfiguration
    {
        public static void InitAwsLambda(this IServiceCollection services, IWebHostEnvironment environment)
        {
            if (!environment.IsDevelopment())
            {
                services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);
            }
        }
    }
}
