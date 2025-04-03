export type HealthServiceDashboard = {
    serviceName: string;
    url: string;
    port: number;
    status: "healthy" | "unhealthy";
}