import { useEffect, useState } from 'react';
import {
    ErrorPL,
    LoadingKanjiPL,
    LoadingProblemPL,
    NoKanjiPL, RefreshPagePL,
    thCharacterPL,
    thKunyomiPL,
    thOnyomiPL,
    thSentencesPL,
    thStrokesPL,
    thTranslationPL
} from "@/Main/Constants.jsx";
import formAddKanji from './FormAddKanji';

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
        const tableKanji =
        <>
            <table>
                <thead>
                    <th>{thCharacterPL}</th>
                    <th>{thStrokesPL}</th>
                    <th>{thTranslationPL}</th>
                    <th>{thKunyomiPL}</th>
                    <th>{thOnyomiPL}</th>
                    <th>{thSentencesPL}</th>
                </thead>
                <tbody>
                    {kanji.map(k =>
                        <>
                            <tr>
                                <td>{k.character}</td>
                                <td>{k.strokes}</td>
                                <td>{k.translation}</td>
                                <td>{k.kunyomi}</td>
                                <td>{k.onyomi}</td>
                                <td id="sampleSentences">{k.sentences.map(s =>
                                    <>
                                        <p>{s.sentenceKanji} -「{s.readingKanjiInSentence}」- {s.translationReadingKanjiInSentence}</p>
                                        <p>{s.translation}</p>
                                        <p>{s.sentence}</p>
                                        <hr id="hrSampleSentences"/>
                                    </>
                                )}</td>
                            </tr>
                        </>
                    )}
                </tbody>
            </table>
        </>

        return (
            <>
                {kanji.length > 0
                    ? (tableKanji)
                    : (<p>{NoKanjiPL}</p> /* There is no Kanji... */)
                }
            </>
        );
    }

    return (
        <>
            <h1 id="tabelLabel">Kanji</h1>
            {loading && <p>{LoadingKanjiPL}</p>} {/* Loading Kanji... */}
            {error && <p>{LoadingProblemPL}.</p>} {/*There is a problem witch fetching Kanji.*/ }
            {error && <p>{ErrorPL}: {error}</p>} {/*Error: "${error}".*/ }
            {error && <p>{RefreshPagePL}.</p>} {/*Please refresh the page.*/ }
            {kanji && contentKanji()}
            {kanji && formAddKanji()}
        </>
    );
}