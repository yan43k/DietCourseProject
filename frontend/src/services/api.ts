import type { CalculateDietRequest, DietCalculation, FeedbackRequest } from '../types/diet';

const API_URL = import.meta.env.VITE_API_URL ?? '';

async function request<T>(url: string, options?: RequestInit): Promise<T> {
  const response = await fetch(`${API_URL}${url}`, {
    headers: {
      'Content-Type': 'application/json',
      ...options?.headers
    },
    ...options
  });

  if (!response.ok) {
    const data = await response.json().catch(() => null);
    const validationErrors = data?.errors
      ? Object.values(data.errors).flat().join(' ')
      : '';

    throw new Error(validationErrors || data?.message || data?.title || 'Ошибка при обращении к серверу');
  }

  if (response.status === 204) {
    return undefined as T;
  }

  return response.json();
}

export const api = {
  calculate: (payload: CalculateDietRequest) =>
    request<DietCalculation>('/calculate', {
      method: 'POST',
      body: JSON.stringify(payload)
    }),

  getHistory: (params: URLSearchParams) => request<DietCalculation[]>(`/history?${params.toString()}`),

  deleteHistory: (id: number) =>
    request<void>(`/history/${id}`, {
      method: 'DELETE'
    }),

  sendFeedback: (payload: FeedbackRequest) =>
    request<{ message: string }>('/feedback', {
      method: 'POST',
      body: JSON.stringify(payload)
    })
};
