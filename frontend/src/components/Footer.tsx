import { Link } from 'react-router-dom';

export default function Footer() {
  return (
    <footer className="site-footer">
      <div className="container footer-grid">
        <div>
          <h3>Оптимальная диета</h3>
          <p>Сервис для расчета индивидуальной нормы калорий, БЖУ и примерного рациона.</p>
        </div>
        <div>
          <h4>Контакты</h4>
          <p>Телефон: +7 900 123-45-67</p>
          <p>Email: info@diet-course.ru</p>
          <p>Адрес: г. Москва, ул. Учебная, 12</p>
        </div>
        <div>
          <h4>Ссылки</h4>
          <Link to="/about">О программе</Link>
          <Link to="/calculator">Калькулятор</Link>
          <Link to="/contacts">Политика конфиденциальности</Link>
          <Link to="/contacts">Условия использования</Link>
        </div>
      </div>
      <div className="footer-bottom">© 2026 Оптимальная диета. Все права защищены.</div>
    </footer>
  );
}
