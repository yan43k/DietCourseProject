import { useState } from 'react';
import { NavLink } from 'react-router-dom';

const links = [
  { to: '/', label: 'Главная' },
  { to: '/about', label: 'О программе' },
  { to: '/calculator', label: 'Калькулятор' },
  { to: '/history', label: 'История' },
  { to: '/contacts', label: 'Контакты' }
];

export default function Navbar() {
  const [opened, setOpened] = useState(false);

  return (
    <header className="site-header">
      <div className="container header-inner">
        <NavLink to="/" className="brand" onClick={() => setOpened(false)}>
          <span className="brand-logo">ОД</span>
          <span>
            <strong>Оптимальная диета</strong>
            <small>расчет питания</small>
          </span>
        </NavLink>

        <div className="header-contacts">
          <a href="tel:+79001234567">+7 900 123-45-67</a>
          <a href="mailto:info@diet-course.ru">info@diet-course.ru</a>
        </div>

        <button className="menu-toggle" onClick={() => setOpened(!opened)} aria-label="Открыть меню">
          <span />
          <span />
          <span />
        </button>

        <nav className={opened ? 'nav opened' : 'nav'}>
          {links.map((link) => (
            <NavLink key={link.to} to={link.to} onClick={() => setOpened(false)}>
              {link.label}
            </NavLink>
          ))}
        </nav>
      </div>
    </header>
  );
}
