type InfoCardProps = {
  icon: string;
  title: string;
  text: string;
};

export default function InfoCard({ icon, title, text }: InfoCardProps) {
  return (
    <article className="info-card">
      <div className="info-icon">{icon}</div>
      <h3>{title}</h3>
      <p>{text}</p>
    </article>
  );
}
