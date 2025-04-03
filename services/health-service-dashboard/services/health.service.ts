import { HealthServiceDashboard } from "../types";

// Getting health status of all services
export const getHealthServices = async () => {
    const res = await fetch('/api/health');
    if (!res.ok) {
        throw new Error('Failed to fetch health services');
    }
    const data: HealthServiceDashboard[] = await res.json();
    return data;
};