define(["loading", "apiClient"], function (loading, ApiClient) {
    return function (view) {
        view.addEventListener("viewshow", function () {
            console.log("EmbyRecs settings page loaded.");
            loading.show();

            ApiClient.getPluginConfiguration("EmbyRecs").then(function (config) {
                document.getElementById("chkEnableExtraction").checked = config.EnableExtractionDuringLibraryScan || false;
                document.getElementById("chkEnableLocalMedia").checked = config.EnableLocalMediaFolderSaving || false;
                loading.hide();
            });
        });

        view.querySelector("#embyrecsConfigurationForm").addEventListener("submit", function (event) {
            event.preventDefault();
            loading.show();

            var config = {
                EnableExtractionDuringLibraryScan: document.getElementById("chkEnableExtraction").checked,
                EnableLocalMediaFolderSaving: document.getElementById("chkEnableLocalMedia").checked
            };

            ApiClient.updatePluginConfiguration("EmbyRecs", config).then(function () {
                Dashboard.processPluginConfigurationUpdateResult();
                loading.hide();
            });
        });
    };
});
