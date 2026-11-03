import { useEffect, useState } from "react";

function App() {
  const [api, setApi] = useState("učitavam...");

  useEffect(() => {
    fetch("/api/hello")
      .then((r) => (r.ok ? r.text() : Promise.reject(`HTTP ${r.status}`)))
      .then(setApi)
      .catch((e) => setApi(`greška: ${e}`));
  }, []);

  return (
    <main className="page">
      <h1>App skeleton</h1>
      <p>Frontend radi.</p>
      <p>
        API: <code>{api}</code>
      </p>
    </main>
  );
}

export default App;
export { App };
