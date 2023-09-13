import { useEffect, useRef, useState } from 'react';
import './App.css';

function App() {
  const [tooted, setTooted] = useState([]);
  const idRef = useRef();
  const nameRef = useRef();
  const priceRef = useRef();
  const isActiveRef = useRef();

  const [pakiautomaadid, setPakiautomaadid] = useState([]);
  
  const [prices, setPrices] = useState([]);
  const [chosenCountry, setChosenCountry] = useState("ee");
  const [start, setStart] = useState("");
  const [end, setEnd] = useState("");
  const startRef = useRef();
  const endRef = useRef();

  useEffect(() => {
    if (start !== "" && end !== "") {
      fetch("https://localhost:4444/nordpool/" + chosenCountry + "/" + start + "/" + end)
        .then(res => res.json())
        .then(json => {
          setPrices(json);
        });
    }
  }, [chosenCountry, start, end]);

  function updateStart() {
    const startIso = new Date(startRef.current.value).toISOString();
    setStart(startIso);
  }

  function updateEnd() {
    const endIso = new Date(endRef.current.value).toISOString();
    setEnd(endIso);
  }

  useEffect(() => {
    fetch("https://localhost:7146/nordpool/" + chosenCountry)
      .then(res => res.json())
      .then(json => {
        setPrices(json);
      });
  }, [chosenCountry]);
  useEffect(() => {
    fetch("https://localhost:7146/parcelmachine")
      .then(res => res.json())
      .then(json => setPakiautomaadid(json));
  }, []);
  useEffect(() => {
    fetch("https://localhost:7146/Tooted")
      .then(res => res.json())
      .then(json => setTooted(json));
  }, []);

  function kustuta(index) {
    fetch("https://localhost:7146/Tooted/kustuta/" + index, {"method": "DELETE"})
      .then(res => res.json())
      .then(json => setTooted(json));
  }

  ////////////////////////
  function lisa() {
    const uusToode = {
      "id": Number(idRef.current.value),
      "name": nameRef.current.value,
      "price": Number(priceRef.current.value),
      "isActive": isActiveRef.current.checked
    }
    fetch("https://localhost:7146/Tooted/lisa/", {"method": "POST", "body": JSON.stringify(uusToode)})
      .then(res => res.json())
      .then(json => setTooted(json));
  }
  ////////////////////////

  function dollariteks() {
    const kurss = 1.1;
    fetch("https://localhost:7146/Tooted/hind-dollaritesse/" + kurss, {"method": "PATCH"})
      .then(res => res.json())
      .then(json => setTooted(json));
  }

  return (
    <div className="App">
      <label>ID</label> <br />
      <input ref={idRef} type="number" /> <br />
      <label>Nimi</label> <br />
      <input ref={nameRef} type="text" /> <br />
      <label>Hind</label> <br />
      <input ref={priceRef} type="number" /> <br />
      <label>Aktiivne</label> <br />
      <input ref={isActiveRef} type="checkbox" /> <br />
      <button onClick={() => lisa()}>Lisa</button>
      {tooted.map((toode, index) => 
        <div>
          <div>{toode.id}</div>
          <div>{toode.name}</div>
          <div>{toode.price}</div>
          <button onClick={() => kustuta(index)}>x</button>
        </div>)}
      <button onClick={() => dollariteks()}>Muuda dollariteks</button>
      <br />
      <select>
        {pakiautomaadid.map(automaat => 
            <option>
                {automaat.NAME}
            </option>)}
      </select>
      <br></br>
      <button onClick={() => setChosenCountry("fi")}>Soome</button>
      <button onClick={() => setChosenCountry("ee")}>Eesti</button>
      <button onClick={() => setChosenCountry("lv")}>Läti</button>
      <button onClick={() => setChosenCountry("lt")}>Leedu</button>
      <br></br>
      <input ref={startRef} onChange={updateStart} type="datetime-local" />
      <input ref={endRef} onChange={updateEnd} type="datetime-local" />
      {prices.length > 0 && 
      <table style={{marginLeft: "100px"}}>
        <thead>
          <th style={{border: "1px solid #ddd", padding: "12px", backgroundColor: "#04AA6D"}}>Ajatempel</th>
          <th style={{border: "1px solid #ddd", padding: "12px", backgroundColor: "#04AA6D"}}>Hind</th>
        </thead>
        <tbody>
          <td style={{position: "absolute", left: "30px"}}>{chosenCountry}</td>
          {prices.map(data => 
          <tr key={data.timestamp}>
            <td style={{border: "1px solid #ddd", padding: "8px"}}>{new Date(data.timestamp * 1000).toISOString()}</td>
            <td style={{border: "1px solid #ddd", padding: "8px"}}>{data.price}</td>
          </tr>)}
        </tbody>
      </table>}
    </div>
  );
}

export default App;