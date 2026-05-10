import { Link } from 'react-router-dom';
import InfoCard from '../components/InfoCard';

export default function HomePage() {
  return (
    <>
      <section className="hero">
        <div className="container hero-grid">
          <div className="hero-content">
            <span className="eyebrow">Сервис питания</span>
            <h1>Расчет оптимальной диеты под вашу цель</h1>
            <p>
              Программа помогает рассчитать норму калорий, белков, жиров и углеводов с учетом пола,
              возраста, роста, веса, активности и цели питания.
            </p>
            <div className="hero-actions">
              <Link className="button primary" to="/calculator">Перейти к калькулятору</Link>
              <Link className="button secondary" to="/about">Подробнее о проекте</Link>
            </div>
          </div>
          <div className="hero-panel">
            <div className="nutrition-circle">БЖУ</div>
            <h2>Персональный рацион</h2>
            <p>Формула Миффлина-Сан Жеора, история расчетов и пример меню на день.</p>
          </div>
        </div>
      </section>

      <section className="section container">
        <div className="section-heading">
          <span className="eyebrow">Преимущества</span>
          <h2>Почему это удобно</h2>
        </div>
        <div className="cards-grid">
          <InfoCard icon="⚖" title="Точный расчет" text="Учитываются основные параметры организма и уровень активности." />
          <InfoCard icon="🥗" title="Меню на день" text="После расчета пользователь получает пример сбалансированного рациона." />
          <InfoCard icon="📊" title="История" text="Все расчеты сохраняются в личной истории и доступны для просмотра и удаления." />
        </div>
      </section>
    </>
  );
}
