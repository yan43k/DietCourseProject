import InfoCard from '../components/InfoCard';

export default function AboutPage() {
  return (
    <section className="section container page-section">
      <div className="section-heading centered">
        <span className="eyebrow">О программе</span>
        <h1>Сервис для расчета оптимального питания</h1>
        <p>
          Мы помогаем быстро подобрать суточную норму калорий, рассчитать БЖУ и получить понятный
          пример дневного рациона под конкретную цель.
        </p>
      </div>

      <div className="about-layout">
        <div className="about-card large">
          <h2>Зачем нужен расчет диеты</h2>
          <p>
            Индивидуальная норма калорий помогает поддерживать здоровье, контролировать вес и планировать рацион.
            Универсальные советы часто не учитывают активность и цель человека, поэтому расчет делает питание более осознанным.
          </p>
        </div>
        <div className="illustration-card">
          <div className="plate">🥗</div>
          <strong>Калории + БЖУ + история</strong>
        </div>
      </div>

      <div className="cards-grid">
        <InfoCard icon="🧮" title="Персональный подход" text="Расчет учитывает параметры тела, цель и уровень ежедневной активности." />
        <InfoCard icon="🥗" title="Готовые рекомендации" text="После расчета вы получаете норму калорий, БЖУ и пример меню на день." />
        <InfoCard icon="📈" title="Контроль прогресса" text="История помогает сравнивать результаты и отслеживать изменения питания." />
      </div>

      <div className="benefits-panel">
        <h2>Преимущества программы</h2>
        <ul>
          <li>понятный русскоязычный интерфейс;</li>
          <li>адаптивная верстка для компьютера, планшета и телефона;</li>
          <li>удобное хранение истории расчетов;</li>
          <li>понятные рекомендации без сложных таблиц и формул.</li>
        </ul>
      </div>
    </section>
  );
}
