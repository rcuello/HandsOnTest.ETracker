import axios from "axios";
import config from "../configuration.json"

const BASE_URL      = config.SERVER_URL;


export const uploadFile = async (formData,successCallback, errorCallback) => {
    const options = {
      method: 'post',
      url: `${BASE_URL}/api/DealerTrack/Parse`,
      data:formData,
      headers: { "Content-Type": "multipart/form-data" }
    };
    await axios.request(options).then(successCallback).catch(errorCallback);
  };