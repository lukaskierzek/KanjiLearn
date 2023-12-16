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
                {kanji.map(k =>
                    <>
                        <table>
                            <tr>Znak: {k.character}</tr>
                            <tr>Liczba znaków: {k.strokes}</tr>
                            <tr>Tłumaczenie: {k.translation}</tr>
                            <tr>Czytanie kunyomi: {k.readings.kunyomi}</tr>
                            <tr>Czytanie onyomi: {k.readings.onyomi}</tr>
                            <tr>Zdania: {k.sentences.map(s =>
                                <>
                                    <p>{s.sentenceKanji} -「{s.readingKanjiInSentence}」- {s.translationReadingKanjiInSentence}</p>
                                    <p>{s.translation}</p>
                                    <p>{s.sentence}</p>
                                    <hr />
                                </>
                            )}</tr>
                        </table>
                        <hr />
                    </>)}
            </>
        );
    }

    return (
        <>
            <h1 id="tabelLabel">Kanji</h1>
            {loading && <p>Ładowanie Kanji...</p>} {/* Loading Kanji... */}
            {error && (<p>{`Problem z ładowaniem Kanji. Błąd: "${error}". Odśwież stronę.`}</p>)} {/*There is a problem witch fetching Kanji. Error: "${error}". Please refresh the page.*/ }
            {kanji && contentKanji()}
        </>
    );
}