import { fieldsetLegendPL, thCharacterPL } from "./Constants";

export default function formAddKanji(){
    return (
        <>
            <p>There is a form to add Kanji</p>
            <form>
                <fieldset>
                    <legend>{fieldsetLegendPL}</legend>
                    <label htmlFor="sign">{thCharacterPL}: </label>
                    <input type="text" id="sign" />
                </fieldset>
            </form>
        </>
    );
}