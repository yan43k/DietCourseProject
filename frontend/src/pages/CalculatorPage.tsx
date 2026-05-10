import { FormEvent, useState } from 'react';
import { api } from '../services/api';
import type { CalculateDietRequest, DietCalculation } from '../types/diet';

const initialForm: CalculateDietRequest = {
  name: '',
  gender: 'Женский',
  age: 25,
  height: 170,
  weight: 65,
  goal: 'Поддержание веса',
  activityLevel: 'Умеренная активность'
};

export default function CalculatorPage() {
  const [form, setForm] = useState(initialForm);
  const [result, setResult] = useState<DietCalculation | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');

  const update = (field: keyof CalculateDietRequest, value: string | number) => {
    setForm((current) => ({ ...current, [field]: value }));
  };

  const submit = async (event: FormEvent) => {
    event.preventDefault();
    setLoading(true);
    setError('');

    try {
      const data = await api.calculate(form);
      setResult(data);
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Не удалось выполнить расчет');
    } finally {
      setLoading(false);
    }
  };

  return (
    <section className="section container page-section">
      <div className="section-heading centered">
        <span className="eyebrow">Калькулятор диеты</span>
        <h1>Введите данные для расчета</h1>
        <p>Расчет выполняется по формуле Миффлина-Сан Жеора и сохраняется в историю.</p>
      </div>

      <div className="calculator-grid">
        <form className="form-card" onSubmit={submit}>
          <label>
            Имя
            <input value={form.name} onChange={(e) => update('name', e.target.value)} placeholder="Например, Мария" required />
          </label>

          <div className="form-row">
            <label>
              Пол
              <select value={form.gender} onChange={(e) => update('gender', e.target.value)}>
                <option>Женский</option>
                <option>Мужской</option>
              </select>
            </label>
            <label>
              Возраст
              <input type="number" min="10" max="100" value={form.age} onChange={(e) => update('age', Number(e.target.value))} required />
            </label>
          </div>

          <div className="form-row">
            <label>
              Рост, см
              <input type="number" min="100" max="250" value={form.height} onChange={(e) => update('height', Number(e.target.value))} required />
            </label>
            <label>
              Вес, кг
              <input type="number" min="30" max="250" value={form.weight} onChange={(e) => update('weight', Number(e.target.value))} required />
            </label>
          </div>

          <label>
            Цель
            <select value={form.goal} onChange={(e) => update('goal', e.target.value)}>
              <option>Похудение</option>
              <option>Поддержание веса</option>
              <option>Набор массы</option>
            </select>
          </label>

          <label>
            Уровень активности
            <select value={form.activityLevel} onChange={(e) => update('activityLevel', e.target.value)}>
              <option>Минимальная активность</option>
              <option>Легкая активность</option>
              <option>Умеренная активность</option>
              <option>Высокая активность</option>
              <option>Очень высокая активность</option>
            </select>
          </label>

          {error && <div className="alert error">{error}</div>}
          <button className="button primary full" disabled={loading}>{loading ? 'Расчет...' : 'Рассчитать диету'}</button>
        </form>

        <div className="result-area">
          {result ? (
            <>
              <div className="result-card highlight">
                <span>Суточная норма</span>
                <strong>{result.calories} ккал</strong>
                <p>Цель: {result.goal}</p>
              </div>
              <div className="macro-grid">
                <div className="result-card"><span>Белки</span><strong>{result.proteins} г</strong></div>
                <div className="result-card"><span>Жиры</span><strong>{result.fats} г</strong></div>
                <div className="result-card"><span>Углеводы</span><strong>{result.carbohydrates} г</strong></div>
              </div>
              <div className="menu-card">
                <h3>Пример меню на день</h3>
                <p>{result.menuPlan}</p>
              </div>
            </>
          ) : (
            <div className="empty-state">
              <h3>Результат появится здесь</h3>
              <p>Заполните форму и нажмите кнопку расчета.</p>
            </div>
          )}
        </div>
      </div>
    </section>
  );
}
