import { useEffect, useState } from 'react';

export default function App() {
    const [kanji, setKanji] = useState();
    const [error, setError] = useState();
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        getKanjiData();
    }, []);

    async function getKanjiData() {
        try {
            const kanjiResponse = await fetch("api/kanji"); //https://localhost:5173/api/kanji

            if (!kanjiResponse.ok)
                throw new Error(`HTTP error ${kanjiResponse.status}`);

            const kanjiData = await kanjiResponse.json();
            setKanji(kanjiData);
            setError(null);
        } catch (e) {
            console.error(e);
            setKanji(null);
            setError(e.message);
        } finally {
            setLoading(false);
        }
    }

    function contentKanji() {
        return (
            <>
                <table>
                    <thead>
                        <th>Znak</th>
                        <th>Liczka kresek</th>
                        <th>Tłumaczenie</th>
                        <th>Czytanie kunyomi</th>
                        <th>Czytanie onyomi</th>
                        <th>Przykładowe zdania</th>
                    </thead>
                    <tbody>
                        {kanji.map(k =>
                            <>
                                <tr>
                                    <td>{k.character}</td>
                                    <td>{k.strokes}</td>
                                    <td>{k.translation}</td>
                                    <td>{k.readings.kunyomi}</td>
                                    <td>{k.readings.onyomi}</td>
                                    <td id="sampleSentences">{k.sentences.map(s =>
                                        <>
                                            <br />
                                            <p>{s.sentenceKanji} -「{s.readingKanjiInSentence}」- {s.translationReadingKanjiInSentence}</p>
                                            <p>{s.translation}</p>
                                            <p>{s.sentence}</p>
                                        </>
                                    )}</td>
                                </tr>
                            </>
                        ) }
                    </tbody>
                </table>
            </>
        );
    }

    return (
        <>
            <h1 id="tabelLabel">Kanji</h1>
            {loading && <p>Ładowanie Kanji...</p>} {/* Loading Kanji... */}
            {error && <p>{`Problem z ładowaniem Kanji. Błąd: "${error}". Proszę odśwież stronę.`}</p>} {/*There is a problem witch fetching Kanji. Error: "${error}". Please refresh the page.*/ }
            {kanji && contentKanji()}
        </>
    );
}