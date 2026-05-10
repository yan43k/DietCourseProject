export type CalculateDietRequest = {
  name: string;
  gender: string;
  age: number;
  height: number;
  weight: number;
  goal: string;
  activityLevel: string;
};

export type DietCalculation = CalculateDietRequest & {
  id: number;
  activityCoefficient: number;
  calories: number;
  proteins: number;
  fats: number;
  carbohydrates: number;
  menuPlan: string;
  createdAt: string;
};

export type FeedbackRequest = {
  name: string;
  email: string;
  phone?: string;
  message: string;
};
