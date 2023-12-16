import {useEffect, useState} from 'react';
import './App.css';

export default function App() {
    const [kanji, setKanji] = useState();
    const [error, setError] = useState();
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        getKanjiData();
    }, []);

    async function getKanjiData() {
        try {
            const kanjiResponse = await fetch("api/kanji");
            if (!kanjiResponse.ok) {
                throw new Error(`HTTP error: The status is ${kanjiResponse.status}`);
            }
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
                            <tr>Character: {k.character}</tr>
                            <tr>Strokes: {k.strokes}</tr>
                            <tr>Translation: {k.translation}</tr>
                            <tr>Readings kunyomi: {k.readings.kunyomi}</tr>
                            <tr>Readings onyomi: {k.readings.onyomi}</tr>
                            <tr>Sentences: {k.sentences.map(s =>

                                <>
                                    <p>{s.sentenceKanji} - [{s.readingKanjiInSentence}]
                                        - {s.translationReadingKanjiInSentence}</p>
                                    <p>{s.translation}</p>
                                    <p>{s.sentence}</p>
                                    <hr/>
                                </>
                            )}</tr>
                        </table>
                        <hr/>
                    </>)}
            </>
        );
    }

    return (
        <>
            <h1 id="tabelLabel">Kanji</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {loading && <p>Loading Kanji...</p>}
            {error && (<p>{`There is a problem witch fetching Kanji. Error: "${error}". Please refresh the page.`}</p>)}
            {kanji && contentKanji()}
        </>
    );
}