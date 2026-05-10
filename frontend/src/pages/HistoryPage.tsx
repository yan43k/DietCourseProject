import { useEffect, useMemo, useState } from 'react';
import { api } from '../services/api';
import type { DietCalculation } from '../types/diet';

export default function HistoryPage() {
  const [items, setItems] = useState<DietCalculation[]>([]);
  const [search, setSearch] = useState('');
  const [goal, setGoal] = useState('');
  const [sortBy, setSortBy] = useState('date');
  const [sortOrder, setSortOrder] = useState('desc');
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  const params = useMemo(() => {
    const query = new URLSearchParams({ sortBy, sortOrder });
    if (search) query.set('search', search);
    if (goal) query.set('goal', goal);
    return query;
  }, [search, goal, sortBy, sortOrder]);

  const load = async () => {
    setLoading(true);
    setError('');
    try {
      setItems(await api.getHistory(params));
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Не удалось загрузить историю');
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    load();
  }, [params.toString()]);

  const remove = async (id: number) => {
    if (!confirm('Удалить запись из истории?')) return;
    await api.deleteHistory(id);
    await load();
  };

  return (
    <section className="section container page-section">
      <div className="section-heading centered">
        <span className="eyebrow">История расчетов</span>
        <h1>Сохраненные результаты</h1>
        <p>Здесь можно просматривать, фильтровать, сортировать и удалять расчеты.</p>
      </div>

      <div className="filters-card">
        <input placeholder="Поиск по имени" value={search} onChange={(e) => setSearch(e.target.value)} />
        <select value={goal} onChange={(e) => setGoal(e.target.value)}>
          <option value="">Все цели</option>
          <option>Похудение</option>
          <option>Поддержание веса</option>
          <option>Набор массы</option>
        </select>
        <select value={sortBy} onChange={(e) => setSortBy(e.target.value)}>
          <option value="date">По дате</option>
          <option value="name">По имени</option>
          <option value="calories">По калориям</option>
        </select>
        <select value={sortOrder} onChange={(e) => setSortOrder(e.target.value)}>
          <option value="desc">По убыванию</option>
          <option value="asc">По возрастанию</option>
        </select>
      </div>

      {error && <div className="alert error">{error}</div>}
      {loading ? <div className="empty-state">Загрузка истории...</div> : null}

      <div className="history-grid">
        {items.map((item) => (
          <article className="history-card" key={item.id}>
            <div className="history-top">
              <div>
                <h3>{item.name}</h3>
                <p>{new Date(item.createdAt).toLocaleString('ru-RU')}</p>
              </div>
              <button className="delete-button" onClick={() => remove(item.id)}>Удалить</button>
            </div>
            <div className="history-details">
              <span>{item.gender}</span>
              <span>{item.age} лет</span>
              <span>{item.height} см</span>
              <span>{item.weight} кг</span>
              <span>{item.goal}</span>
            </div>
            <div className="macro-grid compact">
              <div><strong>{item.calories}</strong><span>ккал</span></div>
              <div><strong>{item.proteins}</strong><span>белки</span></div>
              <div><strong>{item.fats}</strong><span>жиры</span></div>
              <div><strong>{item.carbohydrates}</strong><span>углеводы</span></div>
            </div>
            <p className="menu-text">{item.menuPlan}</p>
          </article>
        ))}
      </div>

      {!loading && items.length === 0 && <div className="empty-state">Записей пока нет.</div>}
    </section>
  );
}
