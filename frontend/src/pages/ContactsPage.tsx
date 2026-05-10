import { FormEvent, useState } from 'react';
import { api } from '../services/api';

export default function ContactsPage() {
  const [form, setForm] = useState({ name: '', email: '', phone: '', message: '' });
  const [status, setStatus] = useState('');
  const [error, setError] = useState('');

  const submit = async (event: FormEvent) => {
    event.preventDefault();
    setStatus('');
    setError('');

    try {
      const response = await api.sendFeedback(form);
      setStatus(response.message);
      setForm({ name: '', email: '', phone: '', message: '' });
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Не удалось отправить сообщение');
    }
  };

  return (
    <section className="section container page-section">
      <div className="section-heading centered">
        <span className="eyebrow">Контакты</span>
        <h1>Свяжитесь с нами</h1>
        <p>Оставьте сообщение, и мы свяжемся с вами для консультации по питанию.</p>
      </div>

      <div className="contacts-grid">
        <form className="form-card" onSubmit={submit}>
          <label>
            Имя
            <input value={form.name} onChange={(e) => setForm({ ...form, name: e.target.value })} required />
          </label>
          <label>
            Email
            <input type="email" value={form.email} onChange={(e) => setForm({ ...form, email: e.target.value })} required />
          </label>
          <label>
            Телефон
            <input value={form.phone} onChange={(e) => setForm({ ...form, phone: e.target.value })} />
          </label>
          <label>
            Сообщение
            <textarea value={form.message} onChange={(e) => setForm({ ...form, message: e.target.value })} minLength={10} required />
          </label>
          {status && <div className="alert success">{status}</div>}
          {error && <div className="alert error">{error}</div>}
          <button className="button primary full">Отправить сообщение</button>
        </form>

        <aside className="contact-card">
          <h2>Контактная информация</h2>
          <p><strong>Телефон:</strong> +7 900 123-45-67</p>
          <p><strong>Email:</strong> info@diet-course.ru</p>
          <p><strong>Адрес:</strong> г. Москва, ул. Учебная, 12</p>
          <div className="socials">
            <a href="#">ВКонтакте</a>
            <a href="#">Telegram</a>
            <a href="#">YouTube</a>
          </div>
        </aside>
      </div>
    </section>
  );
}
