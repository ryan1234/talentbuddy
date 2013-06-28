library(ggplot2)
library(plyr)

results = read.csv('results1.txt', header=FALSE)
results = rename(results, c("V1"="Algorithm", "V2"="Time"))
mean_results <- aggregate(Time~Algorithm, data=results, FUN="mean")
png("results1.png")
mean_results
ggplot(data=mean_results, aes(x=Algorithm, y=Time, fill=Algorithm)) + 
geom_bar(stat="identity", ymin=0) + 
ggtitle("Source: Random words (33mb), Pattern: Random 100000 bytes") +
xlab("Time (milliseconds)") +
geom_text(aes(label=Time), vjust=3)
coord_flip()
dev.off()
