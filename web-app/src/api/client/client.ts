
export class ApiClient {
    private static readonly API_HOST = 'https://localhost:7128/api';
  
    private static getHeaders(): HeadersInit {
      return {
        'Content-Type': 'application/json',
        'Accept': 'application/json',
      };
    }
  
    public static async get(endpoint: string): Promise<any> {
      const url = `${this.API_HOST}${endpoint}`;
      const response = await fetch(url, {
        method: 'GET',
        headers: this.getHeaders(),
      });
  
      if (!response.ok) {
        throw new Error(`GET request to ${url} failed with status ${response.status}`);
      }
  
      return response.json();
    }
  
    public static async post(endpoint: string, body: any): Promise<any> {
      const url = `${this.API_HOST}${endpoint}`;
      const response = await fetch(url, {
        method: 'POST',
        headers: this.getHeaders(),
        body: JSON.stringify(body),
      });
  
      if (!response.ok) {
        throw new Error(`POST request to ${url} failed with status ${response.status}`);
      }
  
      return response.json();
    }
  }

